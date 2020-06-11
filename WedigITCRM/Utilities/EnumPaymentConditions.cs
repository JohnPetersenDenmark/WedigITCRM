using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Utilities
{
    public enum EnumPaymentConditions
    {
        [Display(Name = "Løbende måned + 30 dage")]
        CurrentMonthPlusThirtyDays,

        [Display(Name = "Netto 30 dage")]
        NettoThirtyDays,

        [Display(Name = "Netto 14 dage")]
        NettoFourteenDays,

        [Display(Name = "Netto 8 dage")]
        NettoEightDays
    }
}
