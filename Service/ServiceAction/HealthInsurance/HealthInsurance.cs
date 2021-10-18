using Data;
using DTO.HealthInsuranceDTO;
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
        public HealthInsuranceService(InsuranceDBContext dbContext) : base(dbContext)
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

        public IQueryable<HealthDTO> GetHealthInsurances()
        {
            throw new NotImplementedException();
        }

        public Task RemoveHealthInsurance(int Templateid, int userid)
        {
            throw new NotImplementedException();
        }

        public Task<long> SaveUpdateHealthInsurance(HealthDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
