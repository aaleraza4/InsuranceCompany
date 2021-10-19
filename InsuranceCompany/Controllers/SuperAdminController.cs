using Common.InsuranceNotification;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Service.ServiceAction.HealthInsurance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace InsuranceCompany.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly IHealthInsuranceService _healthInsuranceService;
        private readonly InsuranceDBContext _insuranceDBContext;
        private readonly IConfiguration _configuration;
        private static string conn = string.Empty;
        private readonly IHubContext<NotificationHub> _hubContext;
        public static int counteer = 0;
        NotificationHub NotificationHub = new NotificationHub();
        public SuperAdminController(IHealthInsuranceService healthInsuranceService, InsuranceDBContext insuranceDBContext, IConfiguration configuration, IHubContext<NotificationHub> hubContext)
        {
            _healthInsuranceService = healthInsuranceService;
            _insuranceDBContext = insuranceDBContext;
            _configuration = configuration;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IEnumerable<HealthInsurance> GetAllMessages()
        {
            conn = _configuration.GetConnectionString("db_string");
            SqlDependency.Start(conn);
            var messages = new List<HealthInsurance>();
            using (var connection = new SqlConnection(conn))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [Id]
                FROM [dbo].[HealthInsurances]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item: new HealthInsurance
                        {
                            Id = (long)reader["Id"]
                        });
                    }
                }
            }
            return messages;
        }

        public void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                counteer+=1;
                _hubContext.Clients.All.SendAsync("ReceiveNotifiction", counteer);
            }
            
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
