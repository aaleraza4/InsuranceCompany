using Common.Helper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.ServiceAction;
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
            services.AddScoped<DbContext, InsuranceDBContext>();
            services.AddScoped<SeederService>();
            services.AddScoped<UserSessionProfileService>();
            #endregion
        }
    }
}
