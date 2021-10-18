using Data;
using DTO.MedicareDTO;
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
        public MedicareInsuranceService(InsuranceDBContext dbContext) : base(dbContext)
        {

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

        public IQueryable<MedicareDTO> GetMedicareInsurances()
        {
            throw new NotImplementedException();
        }

        public Task RemoveMedicareInsurance(int Templateid, int userid)
        {
            throw new NotImplementedException();
        }

        public Task<long> SaveUpdateMedicareInsurance(MedicareDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
