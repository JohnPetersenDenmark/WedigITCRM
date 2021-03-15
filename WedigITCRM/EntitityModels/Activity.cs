using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class Activity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Dato for aktiviteten skal udfyldes")]        
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Adviseringstid skal udfyldes")]       
        public string NotifyOffset { get; set; }

        public bool NotificationIsSent { get; set; }

        [Required(ErrorMessage = "Adviseringstid skal udfyldes")]
        public string Subject { get; set; }
        public string Description { get; set; }

        public int contactPersonId { get; set; }
        public int CompanyId { get; set; }
    
        public string UserId { get; set; }

        public int companyAccountId { get; set; }

        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
