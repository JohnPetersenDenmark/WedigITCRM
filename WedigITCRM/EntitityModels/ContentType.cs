using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class ContentType
    {
        [Key]
        public string Type { get; set; }
        public string FileExtension { get; set; }

        public string IconFileName { get; set; }

    }
}
