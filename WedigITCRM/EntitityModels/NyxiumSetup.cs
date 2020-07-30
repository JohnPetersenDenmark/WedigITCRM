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
        public double NyxiumSubscription1NumberOfMonths { get; set; }
        public double NyxiumSubscription2NumberOfMonths { get; set; }

        public double NyxiumSubscriptionPricePerMonth { get; set; }

        public int PaymentConditionNumberOfDays { get; set; }
        public string PaymentConditionType { get; set; }
    }
}
