using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class Note
    {
        public int Id { get; set; }
      
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string AttachedFilesNameAndPath { get; set; }
        public string AttachedmentIds { get; set; }
        public string FileNamesOnly { get; set; }
        public string IconsFilePathAndName { get; set; }
        public int CompanyId { get; set; }
        public string ContentTypes { get; set; }
        public int contactPersonId { get; set; }
        
        public DateTime Date { get; set; }
        public int companyAccountId { get; set; }

        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
