using Data.BaseTable;
using Data.Model;
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
        [ForeignKey("User")]
        public int UserId { get; set; }
        public bool? CurrentlyInsured { get; set; }
        public bool? Smooker{ get; set; }
        public bool? InstructionCheck { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
