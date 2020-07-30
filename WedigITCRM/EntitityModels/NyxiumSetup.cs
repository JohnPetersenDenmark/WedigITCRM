using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class NyxiumSetup
    {
        public int Id { get; set; }
        public string DineroAPIOrganizationKey { get; set; }
        public string DineroAPIOrganization { get; set; }
        public string NyxiumSubscription1DineroProductGuid { get; set; }
        public string NyxiumSubscription2DineroProductGuid { get; set; }
    }
}
