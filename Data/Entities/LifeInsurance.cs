using Data.BaseTable;
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class LifeInsurance : BaseTrackable<int>
    {
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
