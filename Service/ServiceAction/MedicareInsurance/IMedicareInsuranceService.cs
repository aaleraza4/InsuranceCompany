using DTO.MedicareDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceAction.MedicareInsurance
{
    public interface IMedicareInsuranceService
    {
        Task<long> SaveUpdateMedicareInsurance(MedicareDTO model);
        bool CheckExisting(MedicareDTO model);
        List<MedicareDTO> GetMedicareInsurances();
        MedicareDTO GetMedicareInsurancebyId(int Templateid);
        Task RemoveMedicareInsurance(int Templateid, int userid);
        bool CheckMedicareInsurance(int MedicareInsuranceId);
    }
}
