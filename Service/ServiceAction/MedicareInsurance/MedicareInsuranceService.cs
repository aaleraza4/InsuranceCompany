using Data;
using Data.Model;
using DTO.MedicareDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NT_Service.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction.MedicareInsurance
{
    public class MedicareInsuranceService : Repository<Data.Entities.MedicalInsurance>,IMedicareInsuranceService
    {

        private readonly UserManager<ApplicationUser> userManager;

        public MedicareInsuranceService(UserManager<ApplicationUser> _userManager,InsuranceDBContext dbContext) : base(dbContext)
        {
            userManager = _userManager;
        }

        public bool CheckExisting(MedicareDTO model)
        {
            throw new NotImplementedException();
        }

        public bool CheckMedicareInsurance(int MedicareInsuranceId)
        {
            throw new NotImplementedException();
        }

        public MedicareDTO GetMedicareInsurancebyId(int Templateid)
        {
            throw new NotImplementedException();
        }

        public List<MedicareDTO> GetMedicareInsurances()
        {

            var model = GetAll(x => x.IsActive && x.IsDeleted != true).Include(x=>x.User).Select(x => new MedicareDTO
            {
                GenderId = x.GenderId,
                Address = x.User.Address,
                City = x.User.City,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                CurrentlyInsured = x.CurrentlyInsured == true ? 1 : 0,
                DOB = x.User.DOB.Value,
                HomePhoneNumber =x.User.HomePhoneNumber,
                IPAddress = x.User.IPAddress,
                LeadID = x.User.LeadID,
                Smoker = x.Smooker == true ? 1 : 0,
                State = x.User.State,
                Uninsurable = x.Uninsurable == true ? 1 : 0,
                ZipCode = x.User.ZipCode,
                UserId = x.User.Id,
                Email = x.User.Email
            }).ToList();
            return model;
        }

        public Task RemoveMedicareInsurance(int Templateid, int userid)
        {
            throw new NotImplementedException();
        }

        public async Task<long> SaveUpdateMedicareInsurance(MedicareDTO model)
        {
            int UserID = await AddUserEntry(model);
            var MedicalModel = new Data.Entities.MedicalInsurance();
            MedicalModel.UserId = UserID;
            MedicalModel.Uninsurable = model.Uninsurable == 1 ? true : false;
            MedicalModel.Smooker = model.Smoker == 1 ? true : false;
            MedicalModel.CurrentlyInsured = model.CurrentlyInsured == 1 ? true : false;
            MedicalModel.GenderId = model.GenderId;
            MedicalModel.IsActive = true;
            MedicalModel.IsDeleted = false;
            await Add(MedicalModel);
            
            return UserID;
        }

        private async Task<int> AddUserEntry(MedicareDTO model)
        {
            var user = new ApplicationUser();
            user.Address = model.Address;
            user.City = model.City;
            user.DOB = model.DOB;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.State = model.State;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.EmailConfirmed = true;
            user.HomePhoneNumber = model.HomePhoneNumber;
            user.IPAddress = model.IPAddress;
            user.ZipCode = model.ZipCode;
            user.LeadID = model.LeadID;
            var result = await userManager.CreateAsync(user,"Admin#123");
            if (result.Succeeded)
                return user.Id;
            return 0;
        }
    }
}
