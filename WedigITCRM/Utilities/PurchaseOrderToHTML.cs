using System;
using System.Collections.Generic;
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

        public string generateHTML(int purchaseOrderId)
        {
            string html = "";

            
            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);

            if (purchaseOrder == null)
            {
                return html;
                
            }

            List<PurchaseOrderLine> orderLineList = new List<PurchaseOrderLine>();
            orderLineList = _purchaseOrderLineRepository.GetAllpurchaseOrderLines().Where(purchaseOrderLine => purchaseOrderLine.PurchaseOrderId == purchaseOrderId).ToList();
            if (orderLineList.Count() == 0)
            {
                return html;
            }

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Indkøbsordre</h1></div>
                                <table align='left'>");
            sb.AppendFormat(@"
                                <tr>
                                    <td>{0}</td>
                                    <td>{5}</td>
                                </tr>
                                <tr>
                                    <td>{1}</td>
                                    <td>{6}</td>
                                </tr>
                                <tr>
                                    <td>{2}</td>
                                    <td>{7}</td>
                                </tr>
                                <tr>
                                    <td>{3}</td>
                                    <td>{0}</td>
                                </tr>
                                 <tr>
                                    <td>{4}</td>
                                    <td>{0}</td>
                                </tr>"
                                  , purchaseOrder.VendorName, purchaseOrder.VendorStreet, purchaseOrder.VendorZip + " " + purchaseOrder.VendorCity, purchaseOrder.VendorPhoneNumber,  purchaseOrder.VendorEmail,
                                  purchaseOrder.VendorCurrencyCode, purchaseOrder.VendorDeliveryConditions, purchaseOrder.VendorPaymentConditions);

            sb.Append(@"
                                </table>
                                <table align='left'>
                                    <tr>
                                        <th>Antal</th>
                                        <th>Vare</th>
                                        <th>Varenummer</th>
                                        <th>Enheder</th>
                                    </tr>");

            foreach (var orderLine in orderLineList)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", orderLine.QuantityToOrder, orderLine.VendorItemName, orderLine.VendorItemNumber, orderLine.OurUnit);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");


            return sb.ToString();
        }
    }
}
