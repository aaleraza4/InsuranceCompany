using DTO.LifeInsuranceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction.LifeInsurance
{
    public interface ILifeInsuranceService
    {
        Task<long> SaveUpdateLifeInsurance(LifeInsuranceDTO model);
        bool CheckExisting(LifeInsuranceDTO model);
        List<LifeInsuranceDTO> GetLifeInsurances();
        LifeInsuranceDTO GetLifeInsurancebyId(int Templateid);
        Task RemoveLifeInsurance(int Templateid, int userid);
        bool CheckLifeInsurance(int LifeInsuranceId);
    }
}
