#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8d21f6ec340546326ef06aa9325b420a6add416"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOrder_receivePurchaseOrder), @"mvc.1.0.view", @"/Views/PurchaseOrder/receivePurchaseOrder.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8d21f6ec340546326ef06aa9325b420a6add416", @"/Views/PurchaseOrder/receivePurchaseOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51ba4ac1ae00931e0b6fa2532d3d0a4cf8ec236d", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseOrder_receivePurchaseOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PurchaseOrderReceiveViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Note", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "openAttachment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "downloadAttachment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PurchaseOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "deleteAttachment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("PurchaseOrderInput"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"formcontainer\">\r\n    <div class=\"tableheadline\">\r\n        Indkøbsordre nr. ");
#nullable restore
#line 5 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                    Write(Model.PurchaseOrderDocumentNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>

    <div class=""row"">
        <div class=""col-1"">
            <button type=""submit"" class=""btn btn-info btn-lg"">Gem</button>
        </div>
        <div class=""col-3""></div>
        <div class=""col-1""></div>
        <div class=""col-3""></div>

        <div class=""col-3"">
");
#nullable restore
#line 17 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
             if (Model.AttachedmentIds != null)
            {
                List<string> ExistingAttachedmentList = Model.AttachedmentIds.Split(",").ToList();
                List<string> ExistingAttachedFilesTypeIconPathList = Model.IconsFilePathAndName.Split(",").ToList();
                var index = 0;
                foreach (var ExistingAttachedmentId in ExistingAttachedmentList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=\"", 896, "\"", 947, 1);
#nullable restore
#line 24 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
WriteAttributeValue("", 902, ExistingAttachedFilesTypeIconPathList[index], 902, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"42\" width=\"42\" />\r\n");
#nullable restore
#line 25 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                    index++;
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-1\">\r\n            <label for=\"vendorname\">Leverandør</label>\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 36 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
       Write(Model.VendorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-1\">\r\n            <label for=\"vendorname\">Vores ref.</label>\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 43 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
       Write(Model.OurReference);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-1\">\r\n            <label for=\"VendorReference\">Leverandørs ref.</label>\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 53 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
       Write(Model.VendorReference);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-1\">\r\n            <label for=\"OurOrderingDate\">Bestillingsdato.</label>\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 59 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
       Write(Model.OurOrderingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n");
#nullable restore
#line 62 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
             if (Model.AttachedmentIds != null)
            {
                List<string> ExistingAttachedmentList = Model.AttachedmentIds.Split(",").ToList();
                var index = 0;
                foreach (var ExistingAttachedmentId in ExistingAttachedmentList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8d21f6ec340546326ef06aa9325b420a6add41611144", async() => {
                WriteLiteral("Se ordre");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                                                                           WriteLiteral(ExistingAttachedmentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 69 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                    index++;
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-1\">\r\n            <label for=\"VendorPaymentCondition\">Betalingsbetingelser</label>\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 80 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
       Write(Model.VendorPaymentCondition);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-1\">\r\n            <label for=\"OurWantedDeliveryDate\">Ønsket lev. dato.</label>\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 86 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
       Write(Model.OurWantedDeliveryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n");
#nullable restore
#line 89 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
             if (Model.AttachedmentIds != null)
            {
                List<string> ExistingAttachedmentList = Model.AttachedmentIds.Split(",").ToList();
                var index = 0;
                foreach (var ExistingAttachedmentId in ExistingAttachedmentList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8d21f6ec340546326ef06aa9325b420a6add41615368", async() => {
                WriteLiteral("Gem ordre på disk");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                                                                               WriteLiteral(ExistingAttachedmentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 96 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                    index++;
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-1\"></div>\r\n        <div class=\"col-3\"></div>\r\n        <div class=\"col-1\"></div>\r\n        <div class=\"col-3\"></div>\r\n        <div class=\"col-3\">\r\n");
#nullable restore
#line 109 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
             if (Model.AttachedmentIds != null)
            {
                List<string> ExistingAttachedmentList = Model.AttachedmentIds.Split(",").ToList();
                var index = 0;
                foreach (var ExistingAttachedmentId in ExistingAttachedmentList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8d21f6ec340546326ef06aa9325b420a6add41618863", async() => {
                WriteLiteral("Slet ordrebilag");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 115 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                                                                                      WriteLiteral(ExistingAttachedmentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 116 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
                    index++;
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <hr />\r\n\r\n");
#nullable restore
#line 123 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
     if (Model.OrderLinesToReceive != null)
    {
        foreach (var OrderLine in Model.OrderLinesToReceive)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-1\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a8d21f6ec340546326ef06aa9325b420a6add41622063", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 129 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => OrderLine.QuantityReceived);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    ");
#nullable restore
#line 132 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
               Write(OrderLine.QuantityToOrder);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    ");
#nullable restore
#line 135 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
               Write(OrderLine.OurItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    ");
#nullable restore
#line 138 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
               Write(OrderLine.OurItemNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    ");
#nullable restore
#line 141 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
               Write(OrderLine.VendorItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    ");
#nullable restore
#line 144 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
               Write(OrderLine.VendorItemNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 147 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\receivePurchaseOrder.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PurchaseOrderReceiveViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591