using ENUM.Education;
using ENUM.Occupation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.HealthInsuranceDTO
{
    public class HealthDTO
    {
        [Required(ErrorMessage = "Please select One Option.")]
        public int IsStudent { get; set; }
        [Required(ErrorMessage = "Please select One Option.")]
        public EducationType? Education { get; set; }

        [Required(ErrorMessage = "Please select One Option.")]
        public OccupationType? Occupation { get; set; }
        
        [Display(Name = "HouseHold Income")]
        [Required(ErrorMessage = "This field is required.")]
        //[MinLength(2, ErrorMessage = "Value must be greater than 2.")]
        [Range(1000, 100000000000000, ErrorMessage = "Range is between 1000 to 100000000000000.")]
        public int HouseholdIncome { get; set; }

        [Display(Name = "Number of People Living")]
        [Required(ErrorMessage = "This field is required.")]
        //[MinLength(2, ErrorMessage = "Value must be greater than 2.")]
        [Range(1,10, ErrorMessage = "Range is between 1 to 10.")]
        public int NumberOfPeopleLiving { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Weight { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Height { get; set; }

        [Required(ErrorMessage = "Please select One Option.")]
        public int IsMarried { get; set; }
        public int TreatedByPhysician { get; set; }
        //public bool? CurrentlyInsured { get; set; }
        public int PreExistingOrSmoker { get; set; }
        public bool InstructionCheck { get; set; }

        public string IpAddress { get; set; }
        public string LeadId { get; set; }

        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> EducationList { get; set; }
        public IEnumerable<SelectListItem> OccupationList { get; set; }
    }
}
