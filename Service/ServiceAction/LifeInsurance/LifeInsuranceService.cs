using Data;
using Data.Model;
using DTO.LifeInsuranceDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NT_Service.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction.LifeInsurance
{
    public class LifeInsuranceService : Repository<Data.Entities.LifeInsurance>, ILifeInsuranceService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public LifeInsuranceService(UserManager<ApplicationUser> _userManager, InsuranceDBContext dbContext) : base(dbContext)
        {
            userManager = _userManager;
        }

        public bool CheckExisting(LifeInsuranceDTO model)
        {
            throw new NotImplementedException();
        }

        public bool CheckLifeInsurance(int LifeInsuranceId)
        {
            throw new NotImplementedException();
        }

        public LifeInsuranceDTO GetLifeInsurancebyId(int Templateid)
        {
            throw new NotImplementedException();
        }

        public List<LifeInsuranceDTO> GetLifeInsurances()
        {
            var model = GetAll(x => x.IsActive && x.IsDeleted != true).Include(x => x.User).Select(x => new LifeInsuranceDTO
            {
                GenderId = x.GenderId,
                Address = x.User.Address,
                FirstName = x.User.FirstName,
                HomePhoneNumber = x.User.HomePhoneNumber,
                ZipCode = x.User.ZipCode,
                UserId = x.User.Id,
                LeadID = x.User.LeadID
            }).ToList();
            return model;
        }

        public Task RemoveLifeInsurance(int Templateid, int userid)
        {
            throw new NotImplementedException();
        }

        public async Task<long> SaveUpdateLifeInsurance(LifeInsuranceDTO model)
        {
            int UserID = await AddUserEntry(model);
            var LifeModel = new Data.Entities.LifeInsurance();
            LifeModel.UserId = UserID;
            LifeModel.GenderId = model.GenderId;
            LifeModel.IsActive = true;
            LifeModel.IsDeleted = false;
            await Add(LifeModel);

            return UserID;
        }

        private async Task<int> AddUserEntry(LifeInsuranceDTO model)
        {
            var user = new ApplicationUser();
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Address = model.Address;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.HomePhoneNumber = model.HomePhoneNumber;
            user.ZipCode = model.ZipCode;
            user.LeadID = model.LeadID;
            var result = await userManager.CreateAsync(user, "Admin#123");
            if (result.Succeeded)
                return user.Id;
            return 0;
        }
    }
}

