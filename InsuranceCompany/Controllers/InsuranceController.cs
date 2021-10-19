using Common.Helper;
using DTO.HealthInsuranceDTO;
using DTO.MedicareDTO;
using ENUM.Education;
using ENUM.Occupation;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceAction.HealthInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCompany.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IHealthInsuranceService _healthInsuranceService;
        public InsuranceController(IHealthInsuranceService healthInsuranceService)
        {
            _healthInsuranceService = healthInsuranceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MedicareInsurance()
        {
            return View();
        }
        public IActionResult HealthInsurance()
        {
            var model = new HealthDTO();
            model.EducationList = Helper.GetEnumList<EducationType>().ToList();
            model.OccupationList = Helper.GetEnumList<OccupationType>().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult MedicareInsurance(MedicareDTO medicareDTO)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HealthInsurance(HealthDTO healthDTO)
        {
            long Id = 0;
            if(healthDTO != null)
            {
                Id = await _healthInsuranceService.SaveUpdateHealthInsurance(healthDTO);
            }
            return RedirectToAction("SuccessPage", "Insurance",new {Id = Id });
        }

        public IActionResult SuccessPage(long Id)
        {
            return View();
        }
    }
}
