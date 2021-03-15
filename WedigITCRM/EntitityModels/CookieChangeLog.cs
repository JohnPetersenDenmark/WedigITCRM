using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class CookieChangeLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string ClientIPAddress { get; set; }
        public string logText { get; set; }

        public DateTime LoggedDateTime { get; set; }

        
    }
}
