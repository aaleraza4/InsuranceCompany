using Common.InsuranceNotification;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Service.ServiceAction.HealthInsurance;
using Service.ServiceAction.MedicareInsurance;
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
        private readonly IMedicareInsuranceService _medicalInsuranceService;
        private readonly InsuranceDBContext _insuranceDBContext;
        private readonly IConfiguration _configuration;
        private static string conn = string.Empty;
        private readonly IHubContext<NotificationHub> _hubContext;
        public static int counteer = 0;
        NotificationHub NotificationHub = new NotificationHub();
        public SuperAdminController(IMedicareInsuranceService medicalInsuranceService,IHealthInsuranceService healthInsuranceService, InsuranceDBContext insuranceDBContext, IConfiguration configuration, IHubContext<NotificationHub> hubContext)
        {
            _healthInsuranceService = healthInsuranceService;
            _insuranceDBContext = insuranceDBContext;
            _configuration = configuration;
            _hubContext = hubContext;
            _medicalInsuranceService = medicalInsuranceService;
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
            var model = _healthInsuranceService.GetHealthInsurances();
            return View(model);
        }
        public IActionResult MedicareListing()
        {

            return View(_medicalInsuranceService.GetMedicareInsurances());
        }
    }
}
