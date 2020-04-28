using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class RelateCompanyAccountWithUser
    {

        public int id { get; set; }

        public int companyAccount { get; set; }

        public string user { get; set; }

        public string userName { get; set; }

        public string CompanyName { get; set; }
      
    }
}
