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
        public void MedicalNotifiction()
        {

            this.Clients.All.SendAsync("MedicalNotifiction", "Your notification message");

        }
        public void LifeNotifiction()
        {

            this.Clients.All.SendAsync("LifeNotifiction", "Your notification message");

        }
    }
}
