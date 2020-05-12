using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ExtensionMethods
{
    public static class CustomerExtension
    {
        public static Int32 CVRToNumber(this Company company)
        {
            Int32 cvrNumber = 0;
            if (! string.IsNullOrEmpty(company.CVRNumber))
            {
                cvrNumber = Int32.Parse(company.CVRNumber);
            }
            // what a
            return cvrNumber;
        }
    }
}
