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
    public class MedicalInsurance : BaseTrackable<int>
    {
        public bool? Uninsurable { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
