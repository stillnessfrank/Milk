using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFM.Web.Models.SignalR
{
    public class SignalRMessage
    {
        public string msgType;
        public string msgContent;
        public List<string> userList;
    }
}