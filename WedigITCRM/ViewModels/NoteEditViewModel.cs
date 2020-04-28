using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewModels
{
    public class NoteEditViewModel
    {
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string ContentTypes { get; set; }
        public List<string> AttachedmentIds { get; set; }
        public List<string> FileNamesOnly { get; set; }
        public List<string> AttachedFilesNameAndPath { get; set; }
        public List<string> IconsFilePathAndName { get; set; }

        
        public List<string> AttachedFilesTypeIconPath { get; set; }

        public string ExistingAttachedmentIds { get; set; }
        public string ExistingFileNamesOnly { get; set; }
        public string ExistingAttachedFilesNameAndPath { get; set; }
        public string ExistingAttachedFilesTypeIconPath { get; set; }
        
        public List<IFormFile> AttachedFiles { get; set; }

        public int Id { get; set; }
    }
}
