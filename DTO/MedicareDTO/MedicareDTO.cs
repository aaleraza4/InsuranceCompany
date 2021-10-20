using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MedicareDTO
{
    public class MedicareDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public int? ZipCode { get; set; }
        public string HomePhoneNumber { get; set; }
        public string IPAddress { get; set; }
        public int? LeadID { get; set; }
        public DateTime? DOB { get; set; }
        public int Uninsurable { get; set; }
        public int GenderId { get; set; }
        public int UserId { get; set; }
        public int CurrentlyInsured { get; set; }
        public int Smoker { get; set; }
        public int InstructionCheck { get; set; }

    }
}
