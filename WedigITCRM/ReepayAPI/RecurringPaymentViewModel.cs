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
        public string ReepayPlanName { get; set; }
        public string ReepayDiscountId { get; set; }
        public string NyxiumModules { get; set; }
        public string NumberOfBindingDays { get; set; }
        public string AmountBeforeDiscount { get; set; }
        public string AmountAfterDiscount { get; set; }
        public string VATAmount { get; set; }
        public string AmountToPay{ get; set; }
        public string DiscountPercentage { get; set; }
        public string DiscountAmount { get; set; }
        public string CancelUrl { get; set; }
        public string AcceptUrl { get; set; }
        public string CurUserEmail { get; set; }
        public string CurUserPassword { get; set; }
    }
}
