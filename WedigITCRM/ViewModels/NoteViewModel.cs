using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewModels
{
    public class NoteViewModel
    {
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string ContentTypes { get; set; }
        
        public string FileNamesOnly { get; set; }
        public string AttachedmentIds { get; set; }
        public string AttachedFilesNameAndPath { get; set; }
        public List<IFormFile> AttachedFiles { get; set; }

        public int Id { get; set; }

    }
}
