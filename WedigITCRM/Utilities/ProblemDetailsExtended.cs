using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Utilities
{
    public class ProblemDetailsExtended : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
