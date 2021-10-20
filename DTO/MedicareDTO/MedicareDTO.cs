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
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string City { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter only digits.")]
        [Range(0, 1000000000, ErrorMessage = "Range is between 0 to 10000000000.")]
        public int? ZipCode { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter only digits.")]
        [Range(0, 1000000000, ErrorMessage = "Range is between 0 to 10000000000.")]
        public string HomePhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string IPAddress { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int? LeadID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int Uninsurable { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int CurrentlyInsured { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int Smoker { get; set; }
        public bool InstructionCheck { get; set; }

    }
}
