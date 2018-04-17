using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BIMFM.Web
{
    [HubName("emergencyService")]
    public class EmergencyHub : Hub
    {
        [HubMethodName("startEmergencyMode")]
        public void StartEmergencyMode(string name, string msg)
        {
            Clients.All.notify(name, msg);
        }
    }
}