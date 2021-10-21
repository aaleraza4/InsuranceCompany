using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LifeInsuranceDTO
{
    public class LifeInsuranceDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Address { get; set; }
        public int GenderId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter only digits.")]
        [Range(0, 1000000000, ErrorMessage = "Range is between 0 to 10000000000.")]
        public int? ZipCode { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter only digits.")]
        [Range(0, 1000000000, ErrorMessage = "Range is between 0 to 10000000000.")]
        public string HomePhoneNumber { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
        public bool InstructionCheck { get; set; }
    }
}
