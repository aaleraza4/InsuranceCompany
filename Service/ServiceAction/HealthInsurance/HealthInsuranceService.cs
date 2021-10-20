using Data.Model;
using DTO.HealthInsuranceDTO;
using Microsoft.EntityFrameworkCore;
using NT_Service.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction.HealthInsurance
{
    public class HealthInsuranceService : Repository<Data.Entities.HealthInsurance>, IHealthInsuranceService
    {
        public HealthInsuranceService(DbContext dbContext) : base(dbContext)
        {
        }
        public bool CheckExisting(HealthDTO model)
        {
            throw new NotImplementedException();
        }

        public bool CheckHealthInsurance(int HealthInsuranceId)
        {
            throw new NotImplementedException();
        }

        public HealthDTO GetHealthInsurancebyId(int Templateid)
        {
            throw new NotImplementedException();
        }

        public List<HealthDTO> GetHealthInsurances()
        {
            return GetAll(x => x.IsActive && x.IsDeleted != true).Select(x => new HealthDTO
            {
                Education = x.Education,
                GenderId = x.GenderId,
                Height = x.Height,
                HouseholdIncome = x.HouseholdIncome,
                IsMarried = x.IsMarried == true ? 1 : 0,
                IsStudent= x.IsStudent == true ? 1 : 0,
                NumberOfPeopleLiving = x.NumberOfPeopleLiving,
                Occupation = x.Occupation.Value,
                PreExistingOrSmoker = x.PreExistingOrSmoker == true ?1:0,
                TreatedByPhysician = x.TreatedByPhysician == true ?1:0,
                Weight = x.Weight,
                IpAddress = x.IPAddress,
                LeadId = x.LeadID
            }).ToList();
        }

        public Task RemoveHealthInsurance(int Templateid, int userid)
        {
            throw new NotImplementedException();
        }

        public async Task<long> SaveUpdateHealthInsurance(HealthDTO model)
        {
            var HealthModel = new Data.Entities.HealthInsurance();
            HealthModel.CreatedDate = DateTime.Now;
            HealthModel.IsStudent = model.IsStudent == 1 ? true : false;
            HealthModel.IsMarried = model.IsMarried == 1 ? true : false;
            HealthModel.PreExistingOrSmoker = model.PreExistingOrSmoker == 1 ? true : false;
            HealthModel.TreatedByPhysician = model.PreExistingOrSmoker == 1 ? true : false;
            HealthModel.NumberOfPeopleLiving = model.NumberOfPeopleLiving;
            HealthModel.Occupation = model.Occupation;
            HealthModel.Education = model.Education;
            HealthModel.HouseholdIncome = model.HouseholdIncome;
            HealthModel.Weight = model.Weight;
            HealthModel.Height = model.Height;
            HealthModel.GenderId = model.GenderId;
            HealthModel.IPAddress = model.IpAddress;
            HealthModel.IsDeleted = false;
            await Add(HealthModel);
            return HealthModel.Id;
        }

        //private async Task<int> AddUserEntry(HealthDTO model)
        //{
        //    var user = new ApplicationUser();
        //    user.Email = model.Email;
        //    user.UserName = model.Email;
        //    user.EmailConfirmed = true;
        //    user.HomePhoneNumber = model.HomePhoneNumber;
        //    user.IPAddress = model.IPAddress;
        //    user.ZipCode = model.ZipCode;
        //    var result = await userManager.CreateAsync(user, "Admin#123");
        //    if (result.Succeeded)
        //        return user.Id;
        //    return 0;
        //}
    }
}
