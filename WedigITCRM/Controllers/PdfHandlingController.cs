using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;

namespace WedigITCRM.Controllers
{

    // this PDF-solution is free and the description is here: https://code-maze.com/create-pdf-dotnetcore/#dinktopdfconfiguration
    // and the youtube video: https://www.youtube.com/watch?v=J8Ff57Jj6t8
    public class PdfHandlingController : Controller
    {
        private readonly MiscUtility _miscUtility;
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IAttachmentRepository _attachmentRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IConverter _converter;
        private readonly PurchaseOrderToHTML _purchaseOrderToHTML;
        private readonly EmailUtility _emailUtility;

        public PdfHandlingController(MiscUtility miscUtility, IContentTypeRepository contentTypeRepository, IWebHostEnvironment hostingEnvironment, IAttachmentRepository attachmentRepository, IPurchaseOrderRepository purchaseOrderRepository, IConverter converter, PurchaseOrderToHTML purchaseOrderToHTML, EmailUtility emailUtility)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _converter = converter;
            _purchaseOrderToHTML = purchaseOrderToHTML;
            _emailUtility = emailUtility;
            _miscUtility = miscUtility;
            _contentTypeRepository = contentTypeRepository;
            _hostingEnvironment = hostingEnvironment;
            _attachmentRepository = attachmentRepository;
        }




        public IActionResult createPurchaseOrderPDF(int purchaseOrderId, CompanyAccount companyAccount)
        {
            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder == null)
            {
                return Ok("Ingen purchase order id");
            }

            string uploadsFolder = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments";
            string uniqueFileName1 = Guid.NewGuid().ToString() + "_" + "purchaseOrder.pdf";
            string uniqueFilePathAndName = uploadsFolder + "\\" + uniqueFileName1;


            var globalSettings = new DinkToPdf.GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = uniqueFilePathAndName
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = _purchaseOrderToHTML.generateHTML(purchaseOrder, companyAccount),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Side [page] af [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Indkøbsordre" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);


            // make nyxium attachment **********************************************************

            if (!System.IO.File.Exists(uniqueFilePathAndName))
            {
                return Ok("Purchase order PDF-file is not found on disk");
            }

            WedigITCRM.EntitityModels.Attachment attachment = new WedigITCRM.EntitityModels.Attachment();
            attachment.ContentType = "pdf";
            FileInfo info = new FileInfo(uniqueFilePathAndName);            
            attachment.length = info.Length;
            attachment.OriginalFileName = uniqueFilePathAndName;
            attachment.uniqueInternalFileName = uniqueFileName1;
            attachment.companyAccountId = companyAccount.companyAccountId;

            WedigITCRM.EntitityModels.Attachment newAttachment = _attachmentRepository.Add(attachment);

            List<string> fileNamesOnlyList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.FileNamesOnly))
            {
                fileNamesOnlyList = purchaseOrder.FileNamesOnly.Split(",").ToList();
                fileNamesOnlyList.Add(uniqueFileName1);               
                purchaseOrder.FileNamesOnly = string.Join(",", fileNamesOnlyList);
            }
            else
            {
                purchaseOrder.FileNamesOnly = uniqueFileName1;
            }

            List<string> attachmentIdList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.AttachedmentIds))
            {
                attachmentIdList = purchaseOrder.AttachedmentIds.Split(",").ToList();
                attachmentIdList.Add(newAttachment.Id.ToString());
                purchaseOrder.AttachedmentIds = string.Join(",", attachmentIdList);
            }
            else
            {
                purchaseOrder.AttachedmentIds = newAttachment.Id.ToString();
            }

            List<string> AttachedFilesNameAndPathList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.AttachedFilesNameAndPath))
            {
                AttachedFilesNameAndPathList = purchaseOrder.AttachedFilesNameAndPath.Split(",").ToList();
                AttachedFilesNameAndPathList.Add(uniqueFilePathAndName);
                purchaseOrder.AttachedFilesNameAndPath = string.Join(",", AttachedFilesNameAndPathList);
            }
            else
            {
                purchaseOrder.AttachedFilesNameAndPath = newAttachment.Id.ToString();
            }
           
            string iconFilePathAndName = _miscUtility.getIconFilenameAndPath(attachment.ContentType, _contentTypeRepository);

            List<string> IconsFilePathAndNameList = new List<string>();
            if (!string.IsNullOrEmpty(purchaseOrder.IconsFilePathAndName))
            {
                IconsFilePathAndNameList = purchaseOrder.IconsFilePathAndName.Split(",").ToList();
                IconsFilePathAndNameList.Add(iconFilePathAndName);
                purchaseOrder.IconsFilePathAndName = string.Join(",", IconsFilePathAndNameList);
            }
            else
            {
                
                purchaseOrder.IconsFilePathAndName = iconFilePathAndName;
            }

            _purchaseOrderRepository.Update(purchaseOrder);


            // send email with PDF document nyxium attachment **********************************************************

            Dictionary<string, string> tokens = new Dictionary<string, string>();
        tokens.Add("ourcompanyname", companyAccount.CompanyName);
            tokens.Add("ourcompanystreet", companyAccount.CompanyStreet);
            tokens.Add("ourcompanyzip", companyAccount.CompanyZip);
            tokens.Add("ourcompanycity", companyAccount.CompanyCity);

            tokens.Add("ourreference", purchaseOrder.OurReference);
            tokens.Add("purchaseordernumber", purchaseOrder.PurchaseOrderDocumentNumber);

            AlternateView htmlView = _emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.PurchaseOrder, tokens);
        _emailUtility.send("johnpetersen1959@gmail.com", "support@nyxium.dk", "Indkøbsordre nr.: " + purchaseOrder.PurchaseOrderDocumentNumber, htmlView, true, uniqueFilePathAndName);


            return Ok("Successfully created PDF document.");

    }
}
}
