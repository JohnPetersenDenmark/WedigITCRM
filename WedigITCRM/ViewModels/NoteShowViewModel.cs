using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewModels
{
    public class NoteShowViewModel
    {

        public string Subject { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }

        public List<string> FileNamesOnly { get; set; }
        public List<string> AttachedmentIds { get; set; }
        public List<string> IconsFilePathAndName { get; set; }
        public string ContentTypes { get; set; }
        
        public List<string> AttachedFilesNameAndPath { get; set; }
        public List<IFormFile> AttachedFiles { get; set; }

        public int Id { get; set; }
    }
}
