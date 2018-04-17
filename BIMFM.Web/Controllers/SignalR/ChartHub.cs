using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using BIMFM.Web.Models.SignalR;
using Newtonsoft.Json;

namespace BIMFM.Web.Controllers.SignalR
{
    [HubName("ChartHub")]
    public class ChartHub : Hub
    {
        public void Send(string clientName, string message)
        {
            //Clients.All.addNewMessageToPage(clientName, message);
            if (string.IsNullOrEmpty(clientName))
            {
                return;
            }
            SignalRMessage msg = JsonConvert.DeserializeObject<SignalRMessage>(message);
            if (msg.msgType == "user")
            {
                SignalRUsers.Users.Add(msg.msgContent);
                msg.userList = SignalRUsers.Users;
            }
            string JsonMsg = JsonConvert.SerializeObject(msg);
            Clients.All.addNewMessageToPage(clientName, JsonMsg);         
        }
    }
}