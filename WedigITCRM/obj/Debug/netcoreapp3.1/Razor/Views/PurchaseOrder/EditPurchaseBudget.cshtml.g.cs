#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c69e46bcef4b647026ea04f7df9b33bfeb4e2a15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOrder_EditPurchaseBudget), @"mvc.1.0.view", @"/Views/PurchaseOrder/EditPurchaseBudget.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.ViewControllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c69e46bcef4b647026ea04f7df9b33bfeb4e2a15", @"/Views/PurchaseOrder/EditPurchaseBudget.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51ba4ac1ae00931e0b6fa2532d3d0a4cf8ec236d", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseOrder_EditPurchaseBudget : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PurchaseBudgetEditViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("PurchaseBudgetId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"formcontainer\">\r\n    <div class=\"tableheadline\">\r\n        Indkøbsbudget\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n            search\r\n        </div>\r\n    </div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c69e46bcef4b647026ea04f7df9b33bfeb4e2a155210", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 14 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.PurchaseBudgetId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-4\">\r\n");
#nullable restore
#line 18 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                 foreach (var stockItem in Model.StockItems)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"rowcontainer\">\r\n                        <div class=\"row itemline\"");
            BeginWriteAttribute("id", " id=\"", 591, "\"", 609, 1);
#nullable restore
#line 23 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
WriteAttributeValue("", 596, stockItem.Id, 596, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" draggable=\"true\" ondragstart=\"dragStockItemLine(event)\">\r\n                            <div class=\"col-3\">");
#nullable restore
#line 24 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                                          Write(stockItem.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-3\">");
#nullable restore
#line 25 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                                          Write(stockItem.ItemNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-3\">");
#nullable restore
#line 26 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                                          Write(stockItem.Unit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 29 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"col-2\">\r\n\r\n        </div>\r\n\r\n        <div class=\"col-6\">\r\n\r\n\r\n");
#nullable restore
#line 39 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                 foreach (var periodLine in Model.PeriodLines)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>");
#nullable restore
#line 43 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                    Write(periodLine.HeadLine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div");
            BeginWriteAttribute("id", " id=\"", 1289, "\"", 1308, 1);
#nullable restore
#line 44 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
WriteAttributeValue("", 1294, periodLine.Id, 1294, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"row periodcontainer\" ondrop=\"drop(event)\" ondragover=\"allowDrop(event)\">\r\n                        <div style=\"height : 100px\" class=\"col-12\">\r\n\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 49 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\EditPurchaseBudget.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {




            $(document).on('change', '.periodline-input-field', function () {
                var quantity = $(this).val();
                var budgetLineId = $(this).parent().parent().attr(""id"");

                updateBudgetLineQuantity(budgetLineId, quantity);
            });

        });


        function allowDrop(ev) {
            ev.preventDefault();
        }

        function dragStockItemLine(ev) {
            ev.dataTransfer.setData(""text"", ev.target.id + ""|"" + ""1"");
        }

        function dragPeriodLine(ev) {
            ev.dataTransfer.setData(""text"", ev.target.id + ""|"" + ""0"");
        }

        function drop(ev) {

            if (!ev.target.classList.contains(""periodcontainer"")) {
                return;
            }

            ev.preventDefault();

            var data = ev.dataTransfer.getData(""text"");
            var dataArray = data.split(""|"");



            if (dataArray[1] == ""1""");
                WriteLiteral(@") {   // drag and  drop a item line to budget line.

                var stockItemId = dataArray[0];
                var periodLineId = ev.target.getAttribute(""id"");

                createBudgetLineFromItemLine(stockItemId, periodLineId);
            }

            if (dataArray[1] == ""0"") {  // drag and  drop a budget line line to new budget line.
                if (ev.ctrlKey) {
                    var sourceBudgetLineId = dataArray[0];
                    var periodLineId = ev.target.getAttribute(""id"");

                    createBudgetLineFromBudgetLineFromItemLine(sourceBudgetLineId, periodLineId);
                    return;
                }
                else {  // drag and  drop a budget line i.e move

                    var sourceBudgetLineId = dataArray[0];
                    var sourceBudgetLineDiv = document.getElementById(sourceBudgetLineId);

                    var newBudgetLineDiv = sourceBudgetLineDiv.cloneNode(true);

                    sourceBudgetLineDiv.remo");
                WriteLiteral(@"ve();

                    var childDivs = newBudgetLineDiv.getElementsByTagName('input');

                    var sourceQuantity;
                    var sourceperiodeDivId;
                    var sourcestockItemId;
                    for (i = 0; i < childDivs.length; i++) {
                        var inputField = childDivs[i];

                        if (inputField.name == ""periodeDivId"") {
                            sourceperiodeDivId = inputField.value;
                        }

                        if (inputField.name == ""Quantity"") {
                            sourceQuantity = inputField.value;
                        }

                        if (inputField.name == ""stockItemId"") {
                            sourcestockItemId = inputField.value;
                        }
                    }

                    while (childDivs.length > 0) {
                        var inputField = childDivs[0];
                        inputField.remove();
                    }");
                WriteLiteral(@"

                    var childDivs = newBudgetLineDiv.getElementsByTagName('label');
                    var labelNode = childDivs[0];
                    var parentRow = labelNode.parentNode;
                    parentRow.remove();


                    newBudgetLineDiv.innerHTML = ' <div class=""col-3""><label>Antal</label><input type=""text"" name=""Quantity"" class=""periodline-input-field"" value=""' + sourceQuantity + '""/></div>' + newBudgetLineDiv.innerHTML;
                    newBudgetLineDiv.innerHTML = newBudgetLineDiv.innerHTML + '<input type=""text"" hidden name=""periodeDivId"" value=""' + ev.target.getAttribute(""id"") + '"" />';
                    newBudgetLineDiv.innerHTML = newBudgetLineDiv.innerHTML + '<input type=""text"" hidden name=""stockItemId"" value=""' + sourcestockItemId + '"" />';



                    var targetCol = ev.target.firstElementChild;
                    targetCol.appendChild(newBudgetLineDiv);



                    var periodLineId = ev.target.getAttribute(""id"")
     ");
                WriteLiteral(@"               updateBudgetLinePeriod(sourceBudgetLineId, periodLineId)
                }
            }
        }

        function createBudgetLineFromItemLine(stockItemId, periodLineId) {

            $.ajax({
                type: ""POST"",
                url: ""/purchaseorder/createBudgetLineFromItemLine"",
                data: {
                    stockItemId: stockItemId,
                    periodLineId: periodLineId,
                    purchaseBudgetId: $('#PurchaseBudgetId').val()
                },
                contentType: ""application/x-www-form-urlencoded; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {

                    var periodLine = document.getElementById(result.periodLineId);
                    var sourceDiv = document.getElementById(result.stockItemId);

                    sourceDiv.removeAttribute(""ondragstart"");
                    sourceDiv.setAttribute(""ondragstart"", ""dragPeriodLine(event)"")

             ");
                WriteLiteral(@"       sourceDiv.removeAttribute(""id"");
                    sourceDiv.setAttribute(""id"", result.id);

                    sourceDiv.classList.remove(""itemline"");
                    sourceDiv.classList.add(""budgetitemline"");

                    sourceDiv.innerHTML = ' <div class=""col-3""><label>Antal</label><input type=""text"" name=""Quantity"" class=""periodline-input-field"" /></div>' + sourceDiv.innerHTML;
                    sourceDiv.innerHTML = sourceDiv.innerHTML + '<input type=""text"" hidden name=""periodeDivId"" value=""' + result.periodLineId + '"" />';
                    sourceDiv.innerHTML = sourceDiv.innerHTML + '<input type=""text"" hidden name=""stockItemId"" value=""' + result.stockItemId + '"" />';

                    var targetCol = periodLine.firstElementChild;
                    targetCol.append(sourceDiv);
                },

                error: function (request, status, error) {
                    var jsonErrorObj = request.responseJSON
                    var errorText = jsonErr");
                WriteLiteral(@"orObj.Detail;
                    var errorTitle = jsonErrorObj.Title;
                    var errorInstance = jsonErrorObj.Instance;
                    location.href = ""/home/ShowErrorForJSON?errorinstance="" + errorInstance;
                }
            });
        }

        function createBudgetLineFromBudgetLineFromItemLine(sourceBudgetLineId, periodLineId) {

            $.ajax({
                type: ""POST"",
                url: ""/purchaseorder/CreateBudgetLineFromBudgetLine"",
                data: {
                    id: sourceBudgetLineId,
                    periodLineId: periodLineId,
                    purchaseBudgetId: $('#PurchaseBudgetId').val()
                },
                contentType: ""application/x-www-form-urlencoded; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {

                    var periodLine = document.getElementById(result.periodLineId);
                    var htmlStr;

                    htmlStr =");
                WriteLiteral(@" '<div class=""row budgetitemline"" id=""' + result.id + '"" draggable=""true"" ondragstart=""dragPeriodLine(event)"">';
                    htmlStr = htmlStr + ' <div class=""col-3""><label>Antal</label><input type=""text"" name=""Quantity"" class=""periodline-input-field"" value=""' + result.quantityToOrder + '"" /></div>' ;
                    htmlStr = htmlStr + '<div class=""col-3"">' + result.ourItemName + '</div>';
                    htmlStr = htmlStr + '<div class=""col-3"">' + result.ourItemNumber + '</div>';
                    htmlStr = htmlStr + '<div class=""col-3"">' + result.ourItemUnit + '</div>';
                    htmlStr = htmlStr + '<input type=""text"" hidden name=""periodeDivId"" value=""' + result.periodLineId + '"" />';
                    htmlStr = htmlStr + '<input type=""text"" hidden name=""stockItemId"" value=""' + result.stockItemId + '"" />';
                    htmlStr = htmlStr + '</div>';

                    var newDivNode = document.createElement(""div"");
                    newDivNode.innerHTML = ");
                WriteLiteral(@"htmlStr;
                   
                    var targetCol = periodLine.firstElementChild;
                    targetCol.append(newDivNode);
                },

                error: function (request, status, error) {
                    var jsonErrorObj = request.responseJSON
                    var errorText = jsonErrorObj.Detail;
                    var errorTitle = jsonErrorObj.Title;
                    var errorInstance = jsonErrorObj.Instance;
                    location.href = ""/home/ShowErrorForJSON?errorinstance="" + errorInstance;
                }
            });
        }

        function updateBudgetLineQuantity(budgetLineId, Quantity) {

            $.ajax({
                type: ""POST"",
                url: ""/purchaseorder/updateBudgetLineQuantity"",
                data: {
                    id: budgetLineId,
                    quantityToOrder: Quantity,
                    purchaseBudgetId: $('#PurchaseBudgetId').val()
                },
                cont");
                WriteLiteral(@"entType: ""application/x-www-form-urlencoded; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {

                    // Empty
                },

                error: function (request, status, error) {
                    var jsonErrorObj = request.responseJSON
                    var errorText = jsonErrorObj.Detail;
                    var errorTitle = jsonErrorObj.Title;
                    var errorInstance = jsonErrorObj.Instance;
                    location.href = ""/home/ShowErrorForJSON?errorinstance="" + errorInstance;
                }
            });
        }

        function updateBudgetLinePeriod(budgetLineId, periodLineId) {

            $.ajax({
                type: ""POST"",
                url: ""/purchaseorder/updateBudgetLinePeriod"",
                data: {
                    id: budgetLineId,
                    periodLineId: periodLineId,
                    purchaseBudgetId: $('#PurchaseBudgetId').val()
             ");
                WriteLiteral(@"   },
                contentType: ""application/x-www-form-urlencoded; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {

                    // Empty
                },

                error: function (request, status, error) {
                    var jsonErrorObj = request.responseJSON
                    var errorText = jsonErrorObj.Detail;
                    var errorTitle = jsonErrorObj.Title;
                    var errorInstance = jsonErrorObj.Instance;
                    location.href = ""/home/ShowErrorForJSON?errorinstance="" + errorInstance;
                }
            });
        }


    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PurchaseBudgetEditViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
