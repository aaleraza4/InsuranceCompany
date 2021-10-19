using Data.BaseTable;
using ENUM.Education;
using ENUM.Occupation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class HealthInsurance : BaseTrackable<long>
    {
        public bool? IsStudent { get; set; }
        public EducationType? Education { get; set; }
        public OccupationType? Occupation { get; set; }
        public int HouseholdIncome { get; set; }
        public int NumberOfPeopleLiving { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public bool? IsMarried { get; set; }
        public bool? TreatedByPhysician { get; set; }
        //public bool? CurrentlyInsured { get; set; }
        public bool? PreExistingOrSmoker { get; set; }

        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
