using Data.BaseTable;
using Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Gender : BasePrimaryKey<int>, Ilookup
    {
        public string Name { get; set; }
        public ICollection<HealthInsurance> healthInsurances { get; set; }
    }
}
