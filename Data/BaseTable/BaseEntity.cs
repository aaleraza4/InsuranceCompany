using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BaseTable
{
    public abstract class BaseTrackable<T>
    {
        [Key]
        public T Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public DateTime? DeletedDate { get; set; }
    }
    public abstract class BasePrimaryKeyHolder<T>
    {
        [Key]
        public T Id { get; set; }
    }
    public abstract class BasePrimaryKey<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
