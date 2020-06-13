using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class DeliveryCondition
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int companyAccountId { get; set; }
    }
}
