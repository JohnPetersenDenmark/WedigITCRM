using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Utilities
{
    public class PurchaseOrderToHTML
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseOrderLineRepository _purchaseOrderLineRepository;

        public PurchaseOrderToHTML(IPurchaseOrderRepository purchaseOrderRepository, IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _purchaseOrderLineRepository = purchaseOrderLineRepository;
        }

        public string generateHTML(PurchaseOrder purchaseOrder, CompanyAccount companyAccount)
        {
            string html = "";
         

            List<PurchaseOrderLine> orderLineList = new List<PurchaseOrderLine>();
            orderLineList = _purchaseOrderLineRepository.GetAllpurchaseOrderLines().Where(purchaseOrderLine => purchaseOrderLine.PurchaseOrderId == purchaseOrder.Id).ToList();
            if (orderLineList.Count() == 0)
            {
                return html;
            }

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            DateTime myToday = DateTime.Today;

            string myTodayStr = myToday.ToString(danishDateTimeformat.ShortDatePattern);
            string OurWantedDeliveryDate = purchaseOrder.WantedDeliveryDate.ToString(danishDateTimeformat.ShortDatePattern);

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Indkøbsordre</h1></div>
                                <table class='purchaseOrderHeader'>");
            sb.AppendFormat(@"
                                <tr>
                                    <td>{0}</td>
                                    <td></td>
                                    <td>{8}</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>{1}</td>
                                    <td></td>
                                    <td>{9}</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>{2}</td>
                                    <td></td>
                                    <td>{10}</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>{3}</td>
                                    <td></td>
                                    <td>{11}</td>
                                    <td></td>
                                </tr>
                                 <tr>
                                     <td>{4}</td>
                                    <td></td>
                                    <td>{12} {13}</td>
                                    <td></td>
                                </tr>
                                 <tr>
                                    <td>{5}</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                 <tr>
                                     <td>{6} {7}</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr> 
                                </table>
                                <hr>
                                <table class='purchaseOrderHeader'>
                                <tr>
                                     <td>{14}</td>
                                    <td>{15}</td>
                                    <td>{16}</td>
                                    <td>{17}</td>
                                </tr>                            
                                <tr>
                                     <td>{18}</td>
                                    <td>{19}</td>
                                    <td>{20}</td>
                                    <td>{21}</td>                              
                                </tr>
                                     <td>{22}</td>
                                    <td>{23}</td>
                                    <td>{24}</td>
                                    <td>{25}</td>
                                </tr>                          
                                ",
                                  purchaseOrder.VendorName,                                         // 0
                                  purchaseOrder.VendorStreet,                                       // 1
                                  purchaseOrder.VendorZip + " " + purchaseOrder.VendorCity,         // 2
                                  purchaseOrder.VendorCountryCode,                                  // 3
                                  purchaseOrder.VendorPhoneNumber,                                  // 4
                                  purchaseOrder.VendorEmail,                                        // 5   
                                  "Deres ref.:",                                                    // 6
                                  purchaseOrder.VendorReference,                                    // 7   

                                  companyAccount.CompanyName,                                       // 8
                                  companyAccount.CompanyStreet,                                     // 9
                                  companyAccount.CompanyZip + " " + companyAccount.CompanyCity,     // 10
                                  companyAccount.CompanyCountryCode,                                // 11
                                  "Vores ref.:",                                                    // 12
                                  purchaseOrder.OurReference,                                       // 13


                                  "Bestillingsnummer:",                                             // 14
                                  purchaseOrder.PurchaseOrderDocumentNumber,                        // 15
                                  "Ønsket lev. dato:",                                              // 16
                                  OurWantedDeliveryDate,                                            // 17
                                  "Dato:",                                                          // 18
                                  myTodayStr,                                                       // 19
                                  
                                  "Valuta:",                                                        // 20
                                  purchaseOrder.VendorCurrencyCode,                                 // 21
                                  "Leveringsbetingelser:",                                          // 22
                                  purchaseOrder.VendorDeliveryConditions,                           // 23
                                   "Betalingsbetingelser:",                                         // 24                                                                 
                                  purchaseOrder.VendorPaymentConditions);                           // 25




            sb.Append(@"
                                </table>
                                <hr>
                                <br>
                                <table class='purchaseOrderLines'>
                                    <tr>
                                        <th>Lev. varenr.</th>                                        
                                        <th>Vores varenr.</th>
                                        <th>Varebeskrivelse</th>
                                        <th>Enheder</th>
                                        <th>Antal</th>
                                    </tr>");

            foreach (var orderLine in orderLineList)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", orderLine.VendorItemNumber, orderLine.OurItemNumber, orderLine.OurItemName, orderLine.OurUnit, orderLine.QuantityToOrder);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");


            return sb.ToString();
        }
    }
}
