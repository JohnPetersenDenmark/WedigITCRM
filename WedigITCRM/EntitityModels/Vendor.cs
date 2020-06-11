using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.Utilities;

namespace WedigITCRM
{
    public class Vendor
    {
        public int Id { get; set; }

        public string CVRNumber { get; set; }

        [Required(ErrorMessage = "Leverandørnavn skal udfyldes")]
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string ForeignZip { get; set; }
        public string ForeignCity { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }

        public string postalCodeId { get; set; }

        public int companyAccountId { get; set; }
        public CompanyAccount companyAccount { get; set; }
        public Guid DineroGuiD { get; set; }

        public int PaymentConditionsId { get; set; }

        public string PaymentConditions { get; set; }

        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

