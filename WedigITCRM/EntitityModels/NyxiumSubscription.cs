using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class NyxiumSubscription
    {
        public NyxiumSubscriptionDetails[] Subscriptions  { get; set; }
       
    }

    public class NyxiumSubscriptionDetails
    {
        public int Id { get; set; }
       // public string Name { get; set; }
        public string NumberOfNyxiumModules { get; set; }
        public string ReepaySubscriptionPlanHandle { get; set; }
    }
}
