using Common.Helper;
using Common.InsuranceNotification;
using Data;
using Data.Model;
using DTO.Appsettings;
using ENUM.UserRole;
using Insurance.Filters;
using Insurance.Middleware;
using Insurance.RegisterService;
using Insurance.UserExtension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Service.ServiceAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCompany
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }
        public IWebHostEnvironment Env { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region @IDENTITY CONTEXT 
            services.AddDbContext<InsuranceDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("db_string")));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
             .AddEntityFrameworkStores<InsuranceDBContext>()
                .AddDefaultTokenProviders().AddClaimsPrincipalFactory<InsuranceClaimsPrincipleFactory>();
            //services.AddControllersWithViews(x => x.SuppressAsyncSuffixInActionNames = false).AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddRazorPages();
            ResolverService.RegisterModelServices(services, Configuration);
            #endregion
            if (Env.IsDevelopment())
            {
                services.AddControllersWithViews(x => x.SuppressAsyncSuffixInActionNames = false).AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null).AddRazorRuntimeCompilation();
            }
            else
            {
                services.AddControllersWithViews(x => x.SuppressAsyncSuffixInActionNames = false).AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            }
            services.Configure<AppsettingDTO>(options => Configuration.GetSection("AppSettings").Bind(options));
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(48);
            });

            services.AddScoped<JsonExceptionFilter>();
            services.AddScoped<LogExceptionFilter>();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddHttpContextAccessor();
            ResolverService.RegisterModelServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, SeederService seed)
        {
            ServiceActivator.Configure(app.ApplicationServices);
            var dbContext = serviceProvider.GetRequiredService<DbContext>();
            dbContext.Database.Migrate();
            var userid = CreateSuperAdmin(serviceProvider);
            seed.Seed(userid).Wait();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<UserProfileStatusMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Insurance}/{action=MedicareInsurance}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<NotificationHub>("/notificationhub");

            });
        }


        private int CreateSuperAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var appSettings = serviceProvider.GetRequiredService<IOptions<AppsettingDTO>>();

            var userrole = Helper.GetEnumList<UserRole>().ToList();
            var userId = 0;
            Task<bool> role = null;
            foreach (var item in userrole)
            {
                role = roleManager.RoleExistsAsync(item.Text.ToLower());
                role.Wait();
                if (!role.Result)
                {
                    var _role = roleManager.CreateAsync(new ApplicationRole(item.Text.ToLower()));
                    _role.Wait();
                }
            }
            Task<bool> roleExists = roleManager.RoleExistsAsync(UserRole.superadmin.GetEnumDescription().ToLower());
            roleExists.Wait();

            string email = appSettings.Value.SUPER_ADMIN_EMAIL;
            Task<ApplicationUser> superadmin_user = userManager.FindByEmailAsync(email);
            superadmin_user.Wait();
            if (!roleExists.Result || superadmin_user.Result == null)
            {
                if (!roleExists.Result)
                {
                    Task<IdentityResult> roleResult = roleManager.CreateAsync(new ApplicationRole(UserRole.superadmin.GetEnumDescription().ToLower()));
                    roleResult.Wait();
                }
                if (superadmin_user.Result == null)
                {
                    ApplicationUser administrator = new ApplicationUser();
                    administrator.Email = email;
                    administrator.UserName = email;
                    administrator.FirstName = appSettings.Value.FIRST_NAME;
                    administrator.LastName = appSettings.Value.LAST_NAME;
                    administrator.IsDeleted = false;
                    administrator.IsActive = true;
                    administrator.EmailConfirmed = true;
                    Task<IdentityResult> newUser = userManager.CreateAsync(administrator, appSettings.Value.PASSWORD);
                    newUser.Wait();
                    if (newUser.Result.Succeeded)
                    {
                        Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, UserRole.superadmin.GetEnumDescription().ToLower());
                        newUserRole.Wait();
                    }
                    userId = administrator.Id;
                }
            }
            return userId;
        }
    }
}
