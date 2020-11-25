using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class NyxiumSubscriptionDiscounts
    {
        public NyxiumDiscountDetails[] Discounts { get; set; }
    }

    public class NyxiumDiscountDetails
    {
        public int Id { get; set; }
        public string SubscriptionBindingDays { get; set; }      
        public string ReepayDiscountHandle { get; set; }
    }
}
