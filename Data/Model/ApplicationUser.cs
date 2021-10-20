using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ApplicationUser : IdentityUser<int>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? ZipCode { get; set; }
        public string HomePhoneNumber { get; set; }
        public string IPAddress { get; set; }
        public int? LeadID { get; set; }
        public DateTime? DOB { get; set; }
        public ICollection<MedicalInsurance> medicalInsurances { get; set; }
    }
}
