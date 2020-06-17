using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.Utilities;

namespace WedigITCRM.Controllers
{

    // this PDF-solution is free and the description is here: https://code-maze.com/create-pdf-dotnetcore/#dinktopdfconfiguration
    // and the youtube video: https://www.youtube.com/watch?v=J8Ff57Jj6t8
    public class PdfHandlingController : Controller
    {
        private readonly IConverter _converter;
        private readonly PurchaseOrderToHTML _purchaseOrderToHTML;

        public PdfHandlingController(IConverter converter, PurchaseOrderToHTML purchaseOrderToHTML)
        {
            _converter = converter;
           _purchaseOrderToHTML = purchaseOrderToHTML;
        }


        public IActionResult createPurchaseOrderPDF(int purchaseOrderId)
        {
            var globalSettings = new DinkToPdf.GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"C:\PDFCreator\Purchase_Order.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,             
                // HtmlContent = "<html><head></head><body>THIS IS HTML</body></html>",
                HtmlContent = _purchaseOrderToHTML.generateHTML(purchaseOrderId),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Ok("Successfully created PDF document.");
            
        }
    }
}
