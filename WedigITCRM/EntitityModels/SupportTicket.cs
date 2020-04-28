using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class SupportTicket
    {
        //[Key]
        //public int Id { get; set; }

        
        public string Navn { get; set; }
        [Required]
       
        public string Email { get; set; }

        [Required]
        public string Beskrivelse { get; set; }
    }
}
