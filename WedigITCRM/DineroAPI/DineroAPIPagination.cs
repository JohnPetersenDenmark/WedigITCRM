using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.DineroAPI
{
    public class DineroAPIPagination
    {
        public int MaxPageSizeAllowed { get; set; }
        public int PageSize { get; set; }
        public int Result { get; set; }
        public int ResultWithoutFilter { get; set; }
        public int Page { get; set; }        
    }
}
