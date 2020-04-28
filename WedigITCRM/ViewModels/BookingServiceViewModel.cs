using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class BookingServiceViewModel
    {
        public int id { get; set; }

         [Required(ErrorMessage = "Navn skal udfyldes")]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

         [Required(ErrorMessage = "Servicenummer skal udfyldes")]
        [Display(Name = "Servicenummer")]
        public string ProductNumber { get; set; }

         [Range(0, int.MaxValue, ErrorMessage = "Angiv varigheden som et tal ")]
        [Display(Name = "Varighed i minutter")]
        public int durationInMinutes { get; set; }

        [Display(Name = "Kan bookes via hjemmesiden")]
        public bool IsBookable { get; set; }

        [Display(Name = "Spærret tid før servicen ( Angiv i minutter)")]
        [Range(0, int.MaxValue, ErrorMessage = "Angiv spærret tid før servicen")]
        public int GapTimeBeforeInMinutes { get; set; }



        [Display(Name = "Spærret tid efter servicen  ( Angiv i minutter)")]
        [Range(0, int.MaxValue, ErrorMessage = "Angiv spærret tid efter servicen")]
        public int GapTimeAfterInMinutes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Salgspris")]
        public Decimal SalesPrice { get; set; }
        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public int companyAccountId { get; set; }
        public Guid DineroGuiD { get; set; }

    }
}
