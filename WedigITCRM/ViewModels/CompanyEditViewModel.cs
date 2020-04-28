using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.ViewControllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WedigITCRM
{
    public class CompanyEditViewModel 
    {
        public IEnumerable<PostalCode> getSelectableZips;

        public CompanyEditViewModel()
        {
    
        }

        public string selectedZipId { get; set; }

        public string CompanyEditViewFormAction { get; set; }

      
        public Company company { get; set; }

        public List<ContactPerson> ContactPersons { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
