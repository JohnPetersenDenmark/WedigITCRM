using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.Utilities
{
    public class PurchaseOrderToPDF
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConverter _converter;

        public PurchaseOrderToPDF(IWebHostEnvironment hostingEnvironment, IConverter converter)
        {
            _hostingEnvironment = hostingEnvironment;
           _converter = converter;
        }

        public bool generatePurchaseOrderPDF( string HTMLContent, string uniquePDFFilePathAndName)
        {
            string currentDirectory = _hostingEnvironment.WebRootPath;
            string purchaseOrderStyleSheet = Path.Combine(currentDirectory, "lib\\css", "purchaseorder.css");

            var globalSettings = new DinkToPdf.GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = uniquePDFFilePathAndName
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = HTMLContent,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = purchaseOrderStyleSheet },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Side [page] af [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Indkøbsordre" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return true;
        }
       
    }
}
