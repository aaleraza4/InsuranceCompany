using DTO.HealthInsuranceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction.HealthInsurance
{
    public interface IHealthInsuranceService
    {
        Task<long> SaveUpdateHealthInsurance(HealthDTO model);
        bool CheckExisting(HealthDTO model);
        IQueryable<HealthDTO> GetHealthInsurances();
        HealthDTO GetHealthInsurancebyId(int Templateid);
        Task RemoveHealthInsurance(int Templateid, int userid);
        bool CheckHealthInsurance(int HealthInsuranceId);
    }
}
