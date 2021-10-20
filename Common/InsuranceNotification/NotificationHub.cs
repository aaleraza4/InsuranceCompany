using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common.InsuranceNotification
{
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
           
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
        public  void ReceiveNotifiction()
        {

            this.Clients.All.SendAsync("ReceiveNotifiction", "Your notification message");

        }
        public void MedicalInsurance()
        {

            this.Clients.All.SendAsync("MedicalInsurance", "Your notification message");

        }
    }
}
