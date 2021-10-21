using Common.Helper;
using DTO.HealthInsuranceDTO;
using DTO.LifeInsuranceDTO;
using DTO.MedicareDTO;
using ENUM.Education;
using ENUM.Occupation;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceAction.HealthInsurance;
using Service.ServiceAction.LifeInsurance;
using Service.ServiceAction.MedicareInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCompany.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IHealthInsuranceService _healthInsuranceService;
        private readonly IMedicareInsuranceService _medicareInsuranceService;
        private readonly ILifeInsuranceService _lifeInsuranceService;

        public InsuranceController(IMedicareInsuranceService MedicareInsuranceService,IHealthInsuranceService healthInsuranceService, ILifeInsuranceService lifeInsuranceService)
        {
            _healthInsuranceService = healthInsuranceService;
            _medicareInsuranceService = MedicareInsuranceService;
            _lifeInsuranceService = lifeInsuranceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MedicareInsurance()
        {
            return View();
        }
        public IActionResult LifeInsurance()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LifeInsurance(LifeInsuranceDTO lifeInsuranceDTO )
        {
            long Id = 0;
            if (lifeInsuranceDTO != null)
            {
                Id = await _lifeInsuranceService.SaveUpdateLifeInsurance(lifeInsuranceDTO);
            }
            return RedirectToAction("SuccessPage", "Insurance", new { Id = Id });
        }
        public IActionResult FinalExpense()
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
        public async Task<IActionResult> MedicareInsurance(MedicareDTO medicareDTO)
        {
            long Id = 0;
            if (medicareDTO != null)
            {
                Id = await _medicareInsuranceService.SaveUpdateMedicareInsurance(medicareDTO);
            }
            return RedirectToAction("SuccessPage", "Insurance", new { Id = Id });
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
