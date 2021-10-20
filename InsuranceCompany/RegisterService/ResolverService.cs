using Common.Helper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NT_Service.GenericRepository;
using Service.ServiceAction;
using Service.ServiceAction.HealthInsurance;
using Service.ServiceAction.MedicareInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.RegisterService
{
    public class ResolverService
    {
        public static void RegisterModelServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [CONTEXT SERVICES REGISTERATION ----- @@@]
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<DbContext, InsuranceDBContext>();
            services.AddScoped<SeederService>();
            services.AddScoped<UserSessionProfileService>();
            services.AddScoped<IHealthInsuranceService, HealthInsuranceService>();
            services.AddScoped<IMedicareInsuranceService, MedicareInsuranceService>();

            #endregion
        }
    }
}
