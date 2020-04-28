using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class ContactPerson
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fornavn skal udfyldes")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternavn skal udfyldes")]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public string Department { get; set; }
        public int CompanyId { get; set; }

        public int companyAccountId { get; set; }
        public Guid DineroGuiD { get; set; }

        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
