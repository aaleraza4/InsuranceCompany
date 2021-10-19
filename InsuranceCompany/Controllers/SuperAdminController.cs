using Data;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceAction.HealthInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCompany.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly IHealthInsuranceService _healthInsuranceService;
        private readonly InsuranceDBContext _insuranceDBContext;
        public SuperAdminController(IHealthInsuranceService healthInsuranceService,InsuranceDBContext insuranceDBContext)
        {
            _healthInsuranceService = healthInsuranceService;
            _insuranceDBContext = insuranceDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult HealthListing()
        {
            try
            {
                var draw = HttpContext.Request.Query["draw"];

                // Skip number of Rows count  
                var start = HttpContext.Request.Query["start"];

                // Paging Length 10,20  
                var length = HttpContext.Request.Query["length"];

                // Sort Column Name  
                var sortColumn = HttpContext.Request.Query["columns[" + HttpContext.Request.Query["order[0][column]"].FirstOrDefault() + "][name]"];

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = HttpContext.Request.Query["order[0][dir]"];

                // Search Value from (Search box)  
                var searchValue = HttpContext.Request.Query["search[value]"];

                //Paging Size (10, 20, 50,100)  
                int pageSize = Convert.ToInt32(length) ;

                int skip = Convert.ToInt32(start) ;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = (from health in _insuranceDBContext.HealthInsurances
                                    select health);
                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Id == searchValue);
                //}

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = Convert.ToInt32(draw), recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
            }

            
        }
        public IActionResult MedicareListing()
        {
            return View();
        }
    }
}
