using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.ViewModels;



namespace WedigITCRM.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private INoteRepository _noteRepository;
        private IHostingEnvironment _hostingEnvironment;
        private IAttachmentRepository _attachmentRepository;
        private IContentTypeRepository _contentTypeRepository;
        public NoteController(IContentTypeRepository contentTypeRepository, IHostingEnvironment hostingEnvironment, INoteRepository noteRepository, IAttachmentRepository attachmentRepository)
        {
            _noteRepository = noteRepository;
            _hostingEnvironment = hostingEnvironment;
            _attachmentRepository = attachmentRepository;
            _contentTypeRepository = contentTypeRepository;
        }



        public IActionResult ShowDummy(CompanyAccount companyAccount)
        {
            return View();
        }


        public IActionResult Index(CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            List<NoteViewModel> noteOutputList = new List<NoteViewModel>();
            List<Note> noteList = new List<Note>();

            noteList = _noteRepository.GetAllNotes().Where(tmpNote => tmpNote.companyAccountId == companyAccount.companyAccountId).ToList();
            foreach (var note in noteList)
            {
                NoteViewModel model = new NoteViewModel();
                model.Date = note.Date.ToString();
                model.Date = note.Date.ToString(danishDateTimeformat.ShortDatePattern);
                model.Subject = note.Subject;
                model.Comment = note.Comment;
                model.FileNamesOnly = note.FileNamesOnly;
                model.AttachedmentIds = note.AttachedmentIds;
                model.Id = note.Id;
                noteOutputList.Add(model);
            }

            return View(noteOutputList);
        }


        [HttpGet]
        public IActionResult InitContentTypeTable()
        {
            int count = 0;
            int count2 = 0;

            string iconFolder = _hostingEnvironment.WebRootPath + "\\" + "Images\\Icons-filtypes" + "\\";
            List<ContentType> contentTypes = _contentTypeRepository.GetAllContentTypes().ToList();

            foreach (var contentType in contentTypes)
            {
                string iconPathAndFileName = iconFolder + contentType.IconFileName;
                if (System.IO.File.Exists(iconPathAndFileName))
                {
                    count++;
                }
                else
                {
                    contentType.IconFileName = "red-cross.svg";
                    _contentTypeRepository.Update(contentType);
                    count2++;
                }

            }
            return RedirectToAction("Index", "Note");
        }

        [HttpGet]
        public IActionResult NoteCreate(CompanyAccount companyAccount)
        {
            NoteViewModel model = new NoteViewModel();

            DateTime noteDate = DateTime.Now;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            model.Date = noteDate.ToString(danishDateTimeformat.ShortDatePattern);
            return View(model);
        }

        [HttpPost]
        public IActionResult NoteCreate(NoteViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNameList = new List<string>();
                List<string> contentTypeList = new List<string>();
                List<string> attachmentIds = new List<string>();

                if (model.AttachedFiles != null && model.AttachedFiles.Count > 0)
                {
                    int i = 0;
                    string[] fileNameArray = model.FileNamesOnly.Split(",");

                    foreach (var AttachedFile in model.AttachedFiles)
                    {



                        string uploadsFolder = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileNameArray[i];

                        string filePath = uploadsFolder + "\\" + uniqueFileName;
                        uniqueFileNameList.Add(uniqueFileName);
                        contentTypeList.Add(AttachedFile.ContentType);

                        Attachment attachment = new Attachment();
                        attachment.ContentType = AttachedFile.ContentType;
                        attachment.length = AttachedFile.Length;
                        attachment.OriginalFileName = fileNameArray[i];
                        attachment.uniqueInternalFileName = uniqueFileName;
                        attachment.companyAccountId = companyAccount.companyAccountId;
                        Attachment newAttachment = _attachmentRepository.Add(attachment);

                        attachmentIds.Add(newAttachment.Id.ToString());

                        FileStream fs = new FileStream(filePath, FileMode.Create);

                        AttachedFile.CopyTo(fs);
                        fs.Close();

                        i++;
                    }
                }

                DateTime testdate;
                DateTime noteDate;
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                if (DateTime.TryParse(model.Date, out testdate))
                {
                    noteDate = DateTime.Parse(model.Date, danishDateTimeformat);
                }
                else
                {
                    noteDate = DateTime.Now;
                }

                Note note = new Note();
                note.Subject = model.Subject;
                note.Comment = model.Comment;
                note.Date = noteDate;
                note.companyAccountId = companyAccount.companyAccountId;
               

                note.AttachedFilesNameAndPath = string.Join(",", uniqueFileNameList);
                note.FileNamesOnly = model.FileNamesOnly;
                note.AttachedmentIds = string.Join(",", attachmentIds);

                List<string> iconsFilePathAndName = new List<string>();

                if (attachmentIds.Count > 0)
                {
                    foreach (var attachmentId in attachmentIds)
                    {
                        Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(attachmentId));
                        {
                            Utilities.MiscUtility miscUtility = new Utilities.MiscUtility();
                            string iconFilePathAndName = miscUtility.getIconFilenameAndPath(attachment.ContentType, _contentTypeRepository);
                            iconsFilePathAndName.Add(iconFilePathAndName);
                        }
                    }
                    note.IconsFilePathAndName = string.Join(",", iconsFilePathAndName);

                }
                _noteRepository.Add(note);
                return RedirectToAction("Index", "Note");
            }
            return View();
        }

        [HttpGet]
        public IActionResult NoteEdit(string Id, CompanyAccount companyAccount)
        {
            NoteEditViewModel model = new NoteEditViewModel();

            Note note = _noteRepository.GetNote(Int32.Parse(Id));

            if (note != null)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                model.Date = note.Date.ToString(danishDateTimeformat.ShortDatePattern);
                model.Subject = note.Subject;
                model.Comment = note.Comment;
                model.Id = note.Id;

                if (!string.IsNullOrEmpty(note.FileNamesOnly))
                {
                    model.FileNamesOnly = note.FileNamesOnly.Split(",").ToList();
                    model.ExistingFileNamesOnly = note.FileNamesOnly;
                }

                if (!string.IsNullOrEmpty(note.AttachedmentIds))
                {
                    model.AttachedmentIds = note.AttachedmentIds.Split(",").ToList();
                    model.ExistingAttachedmentIds = note.AttachedmentIds;
                }

                if (!string.IsNullOrEmpty(note.AttachedFilesNameAndPath))
                {
                    model.AttachedFilesNameAndPath = note.AttachedFilesNameAndPath.Split(",").ToList();
                    model.ExistingAttachedFilesNameAndPath = note.AttachedFilesNameAndPath;
                }

                if (!string.IsNullOrEmpty(note.IconsFilePathAndName))
                {
                    model.IconsFilePathAndName = note.IconsFilePathAndName.Split(",").ToList();
                    model.ExistingAttachedFilesTypeIconPath = note.IconsFilePathAndName;
                }


            }


            return View(model);
        }




        [HttpPost]
        public IActionResult NoteEdit(NoteEditViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                Note note = _noteRepository.GetNote(model.Id);

                if (note != null)
                {
                    List<string> uniqueFileNameList = new List<string>();
                    List<string> AttachfileIconPathAndName = new List<string>();

                    List<string> attachmentIds = new List<string>();

                    if (model.AttachedFiles != null && model.AttachedFiles.Count > 0)
                    {
                        int i = 0;

                        string[] fileNameArray = model.FileNamesOnly.ToArray();

                        foreach (var AttachedFile in model.AttachedFiles)
                        {
                            string uploadsFolder = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments";
                            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileNameArray[i];
                            string filePath = uploadsFolder + "\\" + uniqueFileName;
                            uniqueFileNameList.Add(uniqueFileName);

                            Utilities.MiscUtility miscUtility = new Utilities.MiscUtility();
                            string iconFilePathAndName = miscUtility.getIconFilenameAndPath(AttachedFile.ContentType, _contentTypeRepository);

                          
                            AttachfileIconPathAndName.Add(iconFilePathAndName);

                            Attachment attachment = new Attachment();
                            attachment.ContentType = AttachedFile.ContentType;
                            attachment.length = AttachedFile.Length;
                            attachment.OriginalFileName = fileNameArray[i];
                            attachment.uniqueInternalFileName = uniqueFileName;
                            attachment.companyAccountId = companyAccount.companyAccountId;
                            Attachment newAttachment = _attachmentRepository.Add(attachment);

                            attachmentIds.Add(newAttachment.Id.ToString());

                            FileStream fs = new FileStream(filePath, FileMode.Create);

                            AttachedFile.CopyTo(fs);
                            fs.Close();

                            i++;
                        }
                    }

                    DateTime testdate;
                    DateTime noteDate;
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                    if (DateTime.TryParse(model.Date, out testdate))
                    {
                        noteDate = DateTime.Parse(model.Date, danishDateTimeformat);
                    }
                    else
                    {
                        noteDate = DateTime.Now;
                    }

                    note.Subject = model.Subject;
                    note.Comment = model.Comment;
                    note.Date = noteDate;

                    if (!string.IsNullOrEmpty(model.ExistingAttachedFilesNameAndPath))
                    {
                        List<string> existingAttachedFilesNameAndPathList = model.ExistingAttachedFilesNameAndPath.Split(",").ToList();
                        foreach (var existinguniqueFileName in existingAttachedFilesNameAndPathList)
                        {
                            uniqueFileNameList.Add(existinguniqueFileName);
                        }
                    }

                    if (!string.IsNullOrEmpty(model.ExistingAttachedmentIds))
                    {
                        List<string> ExistingAttachedmentIdsList = model.ExistingAttachedmentIds.Split(",").ToList();
                        foreach (var ExistingAttachedmentId in ExistingAttachedmentIdsList)
                        {
                            attachmentIds.Add(ExistingAttachedmentId);
                        }
                    }

                    if (!string.IsNullOrEmpty(model.ExistingFileNamesOnly))
                    {
                        List<string> ExistingFileNamesOnlyList = model.ExistingFileNamesOnly.Split(",").ToList();

                        foreach (var ExistingFileNameOnly in ExistingFileNamesOnlyList)
                        {
                            model.FileNamesOnly.Add(ExistingFileNameOnly);
                        }
                    }

                    if (!string.IsNullOrEmpty(model.ExistingAttachedFilesTypeIconPath))
                    {
                        List<string> AttachedFilesTypeIconPathList = model.ExistingAttachedFilesTypeIconPath.Split(",").ToList();
                        foreach (var AttachedFilesTypeIconPath in AttachedFilesTypeIconPathList)
                        {
                            AttachfileIconPathAndName.Add(AttachedFilesTypeIconPath);
                        }
                    }


                    note.AttachedFilesNameAndPath = string.Join(",", uniqueFileNameList);
                    note.FileNamesOnly = string.Join(",", model.FileNamesOnly);
                    note.AttachedmentIds = string.Join(",", attachmentIds);
                    note.IconsFilePathAndName = string.Join(",", AttachfileIconPathAndName);


                    _noteRepository.Update(note);

                    // return RedirectToAction("Index", "Note");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult NoteShow(int Id, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            NoteShowViewModel model = new NoteShowViewModel();
            Note note = _noteRepository.GetNote(Id);
            if (note != null)
            {
                model.Date = note.Date.ToString(danishDateTimeformat.ShortDatePattern);
                model.Subject = note.Subject;
                model.Comment = note.Comment;
                model.Id = note.Id;

                if (!string.IsNullOrEmpty(note.FileNamesOnly))
                {
                    model.FileNamesOnly = note.FileNamesOnly.Split(",").ToList();
                }

                if (!string.IsNullOrEmpty(note.AttachedmentIds))
                {
                    model.AttachedmentIds = note.AttachedmentIds.Split(",").ToList();

                    List<string> iconsFilePathAndName = new List<string>();

                    foreach (var attachmentId in model.AttachedmentIds)
                    {
                        Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(attachmentId));
                        {
                            Utilities.MiscUtility miscUtility = new Utilities.MiscUtility();
                            string iconFilePathAndName = miscUtility.getIconFilenameAndPath(attachment.ContentType, _contentTypeRepository);
                           
                            iconsFilePathAndName.Add(iconFilePathAndName);
                        }
                    }

                    model.IconsFilePathAndName = iconsFilePathAndName;
                }

                if (!string.IsNullOrEmpty(note.AttachedFilesNameAndPath))
                {
                    model.AttachedFilesNameAndPath = note.AttachedFilesNameAndPath.Split(",").ToList();
                }




            }
            return View(model);
        }


        [HttpGet]
        public IActionResult NoteDelete(int Id, CompanyAccount companyAccount)
        {
            Note note = _noteRepository.GetNote(Id);
            if (note != null)
            {
                if (!string.IsNullOrEmpty(note.AttachedmentIds))
                {
                    List<string> AttachedmentIdsList = note.AttachedmentIds.Split(",").ToList();

                    foreach (var attachmentId in AttachedmentIdsList)
                    {
                        Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(attachmentId));
                        if (attachment != null)
                        {
                            string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                            if (System.IO.File.Exists(filePathAndFileName))
                            {
                                System.IO.File.Delete(filePathAndFileName);
                            }

                            _attachmentRepository.Delete(attachment.Id);
                        }
                    }
                }

                _noteRepository.Delete(Id);
            }

            return RedirectToAction("Index", "Note");
        }

        [HttpGet]
        public IActionResult searchInAttachment(string Id, string search, CompanyAccount companyAccount)
        {
            //    https://ybbest.wordpress.com/2011/06/29/retrieve-the-content-of-microsoft-word-document-using-openxml-and-c/

            // https://stackoverflow.com/questions/23102010/open-xml-reading-from-excel-file


            SearchResultViewModel searchResultViewModel = new SearchResultViewModel();
            if (!string.IsNullOrEmpty(Id))
            {
                Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {                                        
                                     
                        if (! string.IsNullOrEmpty(attachment.OriginalFileName))
                        {
                            string content = null;
                            string fileExtension = Path.GetExtension(attachment.OriginalFileName).ToLower();
                            string PDFUrl = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                            Stream stream = System.IO.File.Open(PDFUrl, FileMode.Open);

                            switch (fileExtension)
                            {
                                case ".docx":
                                    WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(stream, false);
                                    Body wordprocessingDocumentBody = wordprocessingDocument.MainDocumentPart.Document.Body;
                                    content = wordprocessingDocumentBody.InnerText;
                                    break;
                                case ".xlsx":
                                    SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(stream, false);
                                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                                    Worksheet sheet = worksheetPart.Worksheet;

                                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                                    SharedStringTable sst = sstpart.SharedStringTable;


                                    var cells = sheet.Descendants<Cell>();
                                    var rows = sheet.Descendants<Row>();
                                    foreach (Cell cell in cells)
                                    {
                                        if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                                        {
                                            int ssid = int.Parse(cell.CellValue.Text);
                                            string str = sst.ChildElements[ssid].InnerText;
                                            Console.WriteLine("Shared string {0}: {1}", ssid, str);
                                        }
                                        else if (cell.CellValue != null)
                                        {
                                            Console.WriteLine("Cell contents: {0}", cell.CellValue.Text);
                                        }
                                    }
                                    break;
                                case ".pdf":
                                    
                                    break;
                                default:
                                    searchResultViewModel.result = "";
                                    break;
                            }                           
                            searchResultViewModel.result = content;
                            return View(searchResultViewModel);
                        }                                       
                }
            }

            searchResultViewModel.result = "indhold ikke fundet";
            return View(searchResultViewModel);
        }


        [HttpGet]
        public FileResult openAttachment(string Id, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string PDFUrl = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                    byte[] FileBytes = System.IO.File.ReadAllBytes(PDFUrl);
                    return File(FileBytes, attachment.ContentType);
                }
            }
            return null;
        }

        public FileResult downloadAttachment(string Id, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                    byte[] FileBytes = System.IO.File.ReadAllBytes(filePathAndFileName);
                    return File(FileBytes, "application/force-download", attachment.uniqueInternalFileName);
                }
            }
            return null;

        }

        public IActionResult deleteAttachment(string Id, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                    if (System.IO.File.Exists(filePathAndFileName))
                    {
                        System.IO.File.Delete(filePathAndFileName);
                    }

                    _attachmentRepository.Delete(attachment.Id);

                    List<Note> noteList = _noteRepository.GetAllNotes().Where(tmpNote => tmpNote.AttachedmentIds.Contains(Id)).ToList();
                    if (noteList.Count == 1)
                    {
                        Note note = noteList.First();

                        List<string> ExistingAttachedmentIdsList = note.AttachedmentIds.Split(",").ToList();
                        List<string> ExistingFileNamesOnlyList = note.FileNamesOnly.Split(",").ToList();
                        List<string> AttachedFilesNameAndPathList = note.AttachedFilesNameAndPath.Split(",").ToList();
                        List<string> IconsFilePathAndNameList = note.IconsFilePathAndName.Split(",").ToList();

                        int index = ExistingAttachedmentIdsList.IndexOf(Id);

                        ExistingAttachedmentIdsList.RemoveAt(index);
                        ExistingFileNamesOnlyList.RemoveAt(index);
                        AttachedFilesNameAndPathList.RemoveAt(index);
                        IconsFilePathAndNameList.RemoveAt(index);

                        note.AttachedmentIds = string.Join(",", ExistingAttachedmentIdsList.ToArray());
                        note.FileNamesOnly = string.Join(",", ExistingFileNamesOnlyList.ToArray());
                        note.AttachedFilesNameAndPath = string.Join(",", AttachedFilesNameAndPathList.ToArray());
                        note.IconsFilePathAndName = string.Join(",", IconsFilePathAndNameList.ToArray());

                        _noteRepository.Update(note);
                    }
                }
            }
            return RedirectToAction("Index", "Note");
        }

      

        public IActionResult ShowAllNotes(CompanyAccount companyAccount)
        {
            return View();
        }

    
        [HttpGet]
        public IActionResult GetNotes(string companyId, string searchAll, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            List<Note> noteList = null;

            List<Attachment> attachmentList = new List<Attachment>();

            NoteOutputDataModel noteOutputDataModel = new NoteOutputDataModel();


           

            if (!string.IsNullOrEmpty(companyId))
            {

                noteList = _noteRepository.GetAllNotes().Where(note => note.CompanyId.ToString().Equals(companyId) && note.companyAccountId == companyAccount.companyAccountId).ToList();
            }
            else
            {
                if (searchAll.Equals("1"))
                {
                    noteList = _noteRepository.GetAllNotes().Where(note => note.companyAccountId == companyAccount.companyAccountId).ToList();
                }
                else
                {
                    noteOutputDataModel.data = new List<NoteModelTest>();
                    return Json(noteOutputDataModel);
                }
                    
            }

           
            foreach (var note in noteList)
            {
                NoteModelTest model = new NoteModelTest();
                model.date = note.Date.ToString(danishDateTimeformat.ShortDatePattern);
                model.subject = note.Subject;
                model.comment = note.Comment;

                if (!string.IsNullOrEmpty(note.AttachedmentIds))
                {
                    List<string> AttachmentIds = note.AttachedmentIds.Split(",").ToList();
                    foreach (var AttachmentId in AttachmentIds)
                    {
                        Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(AttachmentId));
                        if (attachment != null)
                        {
                            NoteFileModelTest file = new NoteFileModelTest();
                            file.id = AttachmentId;
                            model.files.Add(file);

                            attachmentList.Add(attachment);
                        }
                    }
                }

                model.companyId = note.CompanyId.ToString();
                model.id = note.Id.ToString();
                noteOutputDataModel.data.Add(model);

            }


            FilesObjects filesObjects = getFileModels(attachmentList);
            noteOutputDataModel.files = filesObjects;
            return Json(noteOutputDataModel);

        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public string PostedNote(NoteModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (model.upload != null)
                {
                    string uploadsFolder = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments";

                    IFormFile file = model.upload.First();

                    string AttachFileNameOnly = null;
                    string fileExtension = "";

                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        List<string> pathElementsList = file.FileName.Split("\\").ToList();
                        AttachFileNameOnly = pathElementsList.Last();
                        fileExtension = Path.GetExtension(AttachFileNameOnly);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString();
                    string filePath = uploadsFolder + "\\" + uniqueFileName + fileExtension;

                    Attachment attachment = new Attachment();
                    attachment.ContentType = file.ContentType;
                    attachment.length = file.Length;
                    attachment.OriginalFileName = AttachFileNameOnly;
                    attachment.uniqueInternalFileName = uniqueFileName + fileExtension; ;
                    attachment.companyAccountId = companyAccount.companyAccountId;
                    Attachment newAttachment = _attachmentRepository.Add(attachment);

                    FileStream fs = new FileStream(filePath, FileMode.Create);

                    file.CopyTo(fs);
                    fs.Close();

                    string fileExtensionWithoutDot = fileExtension.Substring(fileExtension.LastIndexOf(".") + 1);
                    string IconFilenameAndPath = getIconFilenameAndPathByFileExtension(fileExtensionWithoutDot);

                    string WebPathAndFilename = "/" + "CustomerAttachments" + "/" + uniqueFileName + fileExtension;


                    //string a = "{\"data\": [],\"files\": {\"files\": {\"5\": {\"id\": \"5\", \"filename\": \"image.gif\", \"filesize\": \"361\",\"web_path\": \"/upload/5.gif\",\"system_path\": \"/home/datat/public_html/editor/upload/5.gif\"}}},\"upload\": {\"id\": \"5\"}}";

                    string JsonFileStr = "{\"data\": [],\"files\": {\"files\": {\"" + newAttachment.Id.ToString() + "\": {\"id\": \"" + newAttachment.Id.ToString() + "\", \"filename\": \"" + AttachFileNameOnly + "\", \"filesize\": \"" + file.Length.ToString() + "\",\"web_path\": \"" + IconFilenameAndPath + "\",\"system_path\": \"" + WebPathAndFilename + "\"}}},\"upload\": {\"id\": \"" + newAttachment.Id.ToString() + "\"}}";
                    return JsonFileStr;

                }
            }
            return "";
        }




        [HttpPost]
        [Consumes("application/json")]
        public string PostedNote([FromBody] NoteModelTest model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                List<NoteModelTest> noteListOutput = new List<NoteModelTest>();


                if (model.action.Equals("create"))
                {
                    DateTime testDate;
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    Note note = new Note();
                    if (!string.IsNullOrEmpty(model.date))
                    {
                        if (DateTime.TryParse(model.date, out testDate))
                        {
                            note.Date = DateTime.Parse(model.date, danishDateTimeformat);
                        }
                        else
                        {
                            note.Date = DateTime.Now;
                        }
                    }
                    else
                    {
                        note.Date = DateTime.Now;
                    }

                    note.Subject = model.subject;
                    note.Comment = model.comment;
                    if (!string.IsNullOrEmpty(model.companyId))
                    {
                        note.CompanyId = Int32.Parse(model.companyId);
                    }
                    else
                    {
                        note.CompanyId = 0;
                        model.companyId = "0";
                    }
                    note.companyAccountId = companyAccount.companyAccountId;

                    if (model.files != null)
                    {
                        List<string> fileIds = new List<string>();
                        foreach (var file in model.files)
                        {
                            fileIds.Add(file.id);
                        }

                        note.AttachedmentIds = string.Join(",", fileIds);
                    }

                    Note NewNote = _noteRepository.Add(note);

                    model.id = NewNote.Id.ToString();

                    NoteOutputDataModelTest noteOutputDataModel1 = new NoteOutputDataModelTest();
                    noteOutputDataModel1.data.Add(model);

                    string JsonStr = JsonConvert.SerializeObject(noteOutputDataModel1);

                    return JsonStr;
                }

                if (model.action.Equals("edit"))
                {


                    DateTime testDate;
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    Note note = _noteRepository.GetNote(Int32.Parse(model.id));
                    if (note != null)
                    {
                        if (!string.IsNullOrEmpty(model.date))
                        {
                            if (DateTime.TryParse(model.date, out testDate))
                            {
                                note.Date = DateTime.Parse(model.date, danishDateTimeformat);
                            }
                            else
                            {
                                note.Date = DateTime.Now;
                            }
                        }
                        else
                        {
                            note.Date = DateTime.Now;
                        }

                        List<string> ExistingAttachedmentIds = new List<string>();
                        List<string> userEditedFileIds = new List<string>();
                        List<string> finalFileIds = new List<string>();

                        if (!string.IsNullOrEmpty(note.AttachedmentIds))
                        {
                            ExistingAttachedmentIds = note.AttachedmentIds.Split(",").ToList();
                        }

                        if (model.files != null)
                        {
                            foreach (var file in model.files)
                            {
                                userEditedFileIds.Add(file.id);
                                if (!ExistingAttachedmentIds.Contains(file.id))
                                {
                                    finalFileIds.Add(file.id);
                                }
                            }
                        }

                        if (ExistingAttachedmentIds.Count > 0)
                        {
                            foreach (var ExistingAttachedmentId in ExistingAttachedmentIds)
                            {
                                if (!userEditedFileIds.Contains(ExistingAttachedmentId))
                                {
                                    Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(ExistingAttachedmentId));
                                    if (attachment != null)
                                    {
                                        string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                                        if (System.IO.File.Exists(filePathAndFileName))
                                        {
                                            System.IO.File.Delete(filePathAndFileName);
                                        }
                                        _attachmentRepository.Delete(attachment.Id);
                                    }
                                }
                                else
                                {
                                    finalFileIds.Add(ExistingAttachedmentId);
                                }

                            }
                        }

                        if (finalFileIds.Count > 0)
                        {
                            note.AttachedmentIds = string.Join(",", finalFileIds);
                        }
                        else
                        {
                            note.AttachedmentIds = "";
                        }

                        note.Subject = model.subject;
                        note.Comment = model.comment;
                        Note NewNote = _noteRepository.Update(note);


                        NoteOutputDataModelTest noteOutputDataModelTest = new NoteOutputDataModelTest();
                        noteOutputDataModelTest.data.Add(model);

                        string JsonStr = JsonConvert.SerializeObject(noteOutputDataModelTest);

                        return JsonStr;
                    }
                }

                if (model.action.Equals("remove"))
                {
                    Note note = _noteRepository.GetNote(Int32.Parse(model.id));
                    if (note != null)
                    {
                        if (!string.IsNullOrEmpty(note.AttachedmentIds))
                        {
                            List<string> AttachedmentIdsList = note.AttachedmentIds.Split(",").ToList();

                            foreach (var attachmentId in AttachedmentIdsList)
                            {
                                Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(attachmentId));
                                if (attachment != null)
                                {
                                    string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                                    if (System.IO.File.Exists(filePathAndFileName))
                                    {
                                        System.IO.File.Delete(filePathAndFileName);
                                    }

                                    _attachmentRepository.Delete(attachment.Id);
                                }
                            }
                        }


                        _noteRepository.Delete(note.Id);
                    }

                    string JsonStr = JsonConvert.SerializeObject(model);

                    return JsonStr;
                }

            }
            return "";
        }


        private string getIconFilenameAndPathByFileExtension(string fileExtension)
        {
            string iconFileName = null;
            string iconFilePathAndName = null;

            string fileTypeIconFolder = "/" + "Images/Icons-filtypes";

            List<ContentType> contentTypes = _contentTypeRepository.GetAllContentTypes().Where(type => type.FileExtension.Equals(fileExtension)).ToList();

            if (contentTypes.Count > 0)
            {
                ContentType contentType = contentTypes.First();
                iconFileName = contentType.IconFileName;
            }
            else
            {
                iconFileName = "tmp.svg";
            }


            iconFilePathAndName = fileTypeIconFolder + "/" + iconFileName;

            return iconFilePathAndName;

        }

        public class NoteOutputDataModel
        {
            public NoteOutputDataModel()
            {
                this.data = new List<NoteModelTest>();
            }
            public List<NoteModelTest> data { get; set; }

            public FilesObjects files { get; set; }
        }


        public class UploadedFile
        {
            public string id { get; set; }
            public string filename { get; set; }
            public string filesize { get; set; }
            public string web_path { get; set; }
            public string system_path { get; set; }
        }


        public class Upload
        {
            public string id { get; set; }
        }

        public class UploadFileReturnModel
        {
            public UploadFileReturnModel()
            {
                this.data = new List<object>();
                this.files = new List<UploadedFile>();
            }
            public List<object> data { get; set; }
            public List<UploadedFile> files { get; set; }
            public Upload upload { get; set; }
        }

        public class NoteModelTest
        {
            public NoteModelTest()
            {
                this.files = new List<NoteFileModelTest>();
            }
            public string id { get; set; }
            public string subject { get; set; }
            public string action { get; set; }
            //public string DT_RowId { get; set; }
            public string date { get; set; }
            public string comment { get; set; }
            public List<NoteFileModelTest> files { get; set; }
            public string fileCount { get; set; }
            public string companyId { get; set; }

        }

        public class NoteFileModelTest
        {
            public string id { get; set; }
        }


        public class NoteOutputDataModelTest
        {
            public NoteOutputDataModelTest()
            {
                this.data = new List<NoteModelTest>();
            }
            public List<NoteModelTest> data { get; set; }

        }
        public class NoteModel
        {
            public NoteModel()
            {
                this.files = new List<NoteFileModelTest>();
            }
            public string id { get; set; }
            public string subject { get; set; }
            public string action { get; set; }
            public string date { get; set; }
            public string comment { get; set; }
            public List<string> AttachedmentIds { get; set; }
            public List<NoteFileModelTest> files { get; set; }

            public string uploadField { get; set; }

            public List<IFormFile> upload { get; set; }
        }

        public FilesObjects getFileModels(List<Attachment> attachmentList)
        {
            var files = new ExpandoObject() as IDictionary<string, Object>;

            foreach (var attachment in attachmentList)
            {     
                UploadedFile uploadedFile = new UploadedFile();
                uploadedFile.id = attachment.Id.ToString();
                uploadedFile.filename = attachment.OriginalFileName;
                uploadedFile.filesize = attachment.length.ToString();
                uploadedFile.system_path = "/" + "CustomerAttachments" + "/" + attachment.uniqueInternalFileName;

                string fileExtension = Path.GetExtension(attachment.OriginalFileName);
                string fileExtensionWithoutDot = fileExtension.Substring(fileExtension.LastIndexOf(".") + 1);
                string IconFilenameAndPath = getIconFilenameAndPathByFileExtension(fileExtensionWithoutDot);

                uploadedFile.web_path = IconFilenameAndPath;

                files.Add(uploadedFile.id, uploadedFile);                
            }


            FilesObjects filesContainer = new FilesObjects();
            filesContainer.files = files;

            return filesContainer;

        }

        public class FilesObjects
        {
            public IDictionary<string, Object> files { get; set; }                      
        }

    }
}

