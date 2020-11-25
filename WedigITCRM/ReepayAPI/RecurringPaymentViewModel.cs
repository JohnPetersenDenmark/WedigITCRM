using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public class RecurringPaymentViewModel
    {
        public string SessionId { get; set; }
        public string ReepayPlanId { get; set; }
        public string ReepayDiscountId { get; set; }
        public string CancelUrl { get; set; }
        public string AcceptUrl { get; set; }
    }
}
