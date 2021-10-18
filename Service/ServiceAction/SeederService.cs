using Data;
using Data.Entities;
using DTO.Appsettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction
{
    public class SeederService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly InsuranceDBContext _insuranceDBContext;
        private readonly IOptions<AppsettingDTO> _appSettings;

        public SeederService(IServiceProvider serviceProvider, IOptions<AppsettingDTO> appSettings)
        {
            _serviceProvider = serviceProvider;
            _appSettings = appSettings;
            _insuranceDBContext = _serviceProvider.GetRequiredService<InsuranceDBContext>();
        }

        public async Task Seed(int userId)
        {
            await AddGender();
        }
        private async Task AddGender()
        {
            if (!await _insuranceDBContext.Genders.AnyAsync())
            {
                await _insuranceDBContext.AddRangeAsync(new List<Gender>()
                {
                new Gender {Name = "Male" },
                new Gender {Name = "Female" }
                });
            }
        }

    }
}
