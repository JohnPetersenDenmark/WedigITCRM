#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "618ce4daeaecb6f4bdfb8f518eeee71ed15945aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOrder_IndexBudget), @"mvc.1.0.view", @"/Views/PurchaseOrder/IndexBudget.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"618ce4daeaecb6f4bdfb8f518eeee71ed15945aa", @"/Views/PurchaseOrder/IndexBudget.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fc04a0290131b0b832d4c5c3a26c71284940263", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseOrder_IndexBudget : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<PurchaseBudgetViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PurchaseOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePurchaseBudget", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditPurchaseBudget", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeletePurchaseBudget", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""formcontainer"">
        <div style=""color : #17a2b8;"" class=""tableheadline"">
            Indkøbsbudgetter
        </div>
        <br />

        <div class=""rowcontainer"">
            <div class=""row"">                
                <div class=""col-2"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "618ce4daeaecb6f4bdfb8f518eeee71ed15945aa6865", async() => {
                WriteLiteral("Nyt budget");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n");
#nullable restore
#line 17 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
         if (Model != null)
        {
            if (Model.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""rowcontainer"">
                    <div class=""row purchaseorderindexheadlines"">
                        <div class=""col-1"">Fra</div>
                        <div class=""col-1"">Til</div>
                        <div class=""col-2"">Periode</div>
                        <div class=""col-3"">Beskrivelse</div>                       
                    </div>
                </div>
");
#nullable restore
#line 30 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                 foreach (var purchaseBudget in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"rowcontainer purchaseorderindexorderline\">\r\n                        <div class=\"row\"");
            BeginWriteAttribute("id", " id=\"", 1229, "\"", 1252, 1);
#nullable restore
#line 33 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
WriteAttributeValue("", 1234, purchaseBudget.Id, 1234, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <div class=\"col-1\">");
#nullable restore
#line 34 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                                          Write(purchaseBudget.PeriodFromDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-1\">");
#nullable restore
#line 35 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                                          Write(purchaseBudget.PeriodToDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-2\">");
#nullable restore
#line 36 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                                          Write(purchaseBudget.Period);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-3\">");
#nullable restore
#line 37 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                                          Write(purchaseBudget.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-2\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "618ce4daeaecb6f4bdfb8f518eeee71ed15945aa11389", async() => {
                WriteLiteral("<i style=\"color : #17a2b8;\" class=\"fa fa-pencil-square-o fa-2x fa-fw\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-purchaseBudgetId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                                                                                                                  WriteLiteral(purchaseBudget.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["purchaseBudgetId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-purchaseBudgetId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["purchaseBudgetId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "618ce4daeaecb6f4bdfb8f518eeee71ed15945aa13998", async() => {
                WriteLiteral("<i style=\"color : #17a2b8;\" class=\"fa fa-times fa-2x fa-fw\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-purchaseBudgetId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                                                                                                                    WriteLiteral(purchaseBudget.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["purchaseBudgetId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-purchaseBudgetId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["purchaseBudgetId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 44 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""rowcontainer"">
                    <div class=""row"">
                        <div class=""col-3"">
                            Ingen indkøbsbudgetter fundet
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 55 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <br />\r\n        <br />\r\n        <div class=\"form-row\">\r\n            <div class=\"col-4\">\r\n\r\n                ");
#nullable restore
#line 64 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\PurchaseOrder\IndexBudget.cshtml"
           Write(Html.PagedListPager(Model, page => Url.Action("IndexBudget", new { page }), new PagedListRenderOptions
                {
                    LiElementClasses = new string[] { "page-item" },
                    PageClasses = new string[] { "page-link" },
                    LinkToFirstPageFormat = "<< Første",
                    LinkToPreviousPageFormat = "< Forrige",
                    LinkToNextPageFormat = "Næste >",
                    LinkToLastPageFormat = "sidste >>"
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n\r\n\r\n        $(document).ready(function () {\r\n\r\n \r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<PurchaseBudgetViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
