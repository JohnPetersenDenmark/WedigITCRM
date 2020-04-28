using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
   
        public class Attachment
        {
            public int Id { get; set; }
            public string OriginalFileName { get; set; }
            public int companyAccountId { get; set; }
            public string uniqueInternalFileName { get; set; }
            public long length { get; set; }
            public string ContentType { get; set; }


        }    
}
