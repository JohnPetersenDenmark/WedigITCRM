#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "107c894d9476a254da09add6320c341defc41d46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 6 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.ViewControllers;

#line default
#line hidden
#line 2 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.Models;

#line default
#line hidden
#line 3 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM;

#line default
#line hidden
#line 5 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#line 8 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 9 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"107c894d9476a254da09add6320c341defc41d46", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "searchString", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Søgetekst"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("companyDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(29, 51, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"mysearchbar\">\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(80, 2246, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e61290c19474e6a99c35b753f61bb72", async() => {
                BeginContext(156, 202, true);
                WriteLiteral("\r\n\r\n        <div class=\"form-row\">\r\n            <div class=\"col-2\">\r\n                <span class=\"viewHeadLine\">Virksomheder</span>\r\n            </div>\r\n            <div class=\"col-2\">\r\n                ");
                EndContext();
                BeginContext(358, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b90ef5d7054b4c69b0bb598d1f6cf1b5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 16 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.searchString);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(470, 55, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-2\">\r\n");
                EndContext();
#line 19 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                 if (true)
                {
                    var types = new List<SelectListItem>();
                    types.Add(new SelectListItem() { Text = "Firmanavn", Value = "Name" });
                    types.Add(new SelectListItem() { Text = "Gade", Value = "Street" });
                    types.Add(new SelectListItem() { Text = "By", Value = "City" });
                    types.Add(new SelectListItem() { Text = "Postnummer", Value = "Zip" });

                    

#line default
#line hidden
                BeginContext(1018, 112, false);
#line 27 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
               Write(Html.DropDownList("searchBy", new SelectList(@types, "Value", "Text"), new { @class = "custom-select mr-sm-2" }));

#line default
#line hidden
                EndContext();
#line 27 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                                                                                                                     ;
                }

#line default
#line hidden
                BeginContext(1152, 305, true);
                WriteLiteral(@"            </div>
            <div class=""col-1"">
                <button type=""submit"" style=""height:36px;"" class=""btn icon-menu-background-color""><i class=""fa fa-search icon-menu-background-color"" aria-hidden=""true""></i></button>
            </div>
            <div class=""col-4"">
                ");
                EndContext();
                BeginContext(1458, 628, false);
#line 34 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
           Write(Html.PagedListPager(Model.companies, page => Url.Action("Index", new { page, searchBy = Model.searchBy, searchString = Model.searchString, sortColumn = Model.sortColumn, sortDirection = Model.sortDirection }), new PagedListRenderOptions
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
                EndContext();
                BeginContext(2086, 100, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <input id=\"sortColumn\" type=\"hidden\" name=\"sortColumn\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2186, "\"", 2211, 1);
#line 45 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
WriteAttributeValue("", 2194, Model.sortColumn, 2194, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2212, 71, true);
                WriteLiteral(">\r\n        <input id=\"sortDirection\" type=\"hidden\" name=\"sortDirection\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2283, "\"", 2311, 1);
#line 46 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
WriteAttributeValue("", 2291, Model.sortDirection, 2291, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2312, 7, true);
                WriteLiteral(">\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2326, 2398, true);
            WriteLiteral(@"
</div>

<div class=""sortcontainer"">
    <div class=""row"">
        <div class=""col-3 columnheader"">
            Virksomhed
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Name"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Name"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Gade
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Street"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Street"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            ");
            WriteLiteral(@"Postnr.
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Zip"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Zip"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            By
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""City"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""City"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Telefon
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Phone"" sortdirection=""Ascending""><i clas");
            WriteLiteral(@"s=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Phone"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-1 columnheader"">
        </div>
    </div>
</div>

");
            EndContext();
#line 82 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#line 84 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
     foreach (var company in Model.companies)
    {

#line default
#line hidden
            BeginContext(4802, 64, true);
            WriteLiteral("        <div class=\"rowcontainer\">\r\n            <div class=\"row\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4866, "\"", 4882, 1);
#line 87 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
WriteAttributeValue("", 4871, company.Id, 4871, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4883, 50, true);
            WriteLiteral(">\r\n                <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(4934, 12, false);
#line 88 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                          Write(company.Name);

#line default
#line hidden
            EndContext();
            BeginContext(4946, 55, true);
            WriteLiteral("</div>\r\n                <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5002, 14, false);
#line 89 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                          Write(company.Street);

#line default
#line hidden
            EndContext();
            BeginContext(5016, 55, true);
            WriteLiteral("</div>\r\n                <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5072, 11, false);
#line 90 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                          Write(company.Zip);

#line default
#line hidden
            EndContext();
            BeginContext(5083, 55, true);
            WriteLiteral("</div>\r\n                <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5139, 12, false);
#line 91 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                          Write(company.City);

#line default
#line hidden
            EndContext();
            BeginContext(5151, 55, true);
            WriteLiteral("</div>\r\n                <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5207, 19, false);
#line 92 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                          Write(company.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(5226, 279, true);
            WriteLiteral(@"</div>
                <div class=""col-1"">
                    <div class=""dropdown"">
                        <div class=""dropbtn""><i class=""fa fa-bars icon-menu-background-color""></i></div>
                        <div class=""dropdown-content"">
                            ");
            EndContext();
            BeginContext(5505, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "841b18af3afb4531a4a2ef84247b0b3f", async() => {
                BeginContext(5597, 7, true);
                WriteLiteral("Rediger");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 97 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                                                         WriteLiteral(company.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5608, 32, true);
            WriteLiteral("\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5640, "\"", 5664, 1);
#line 98 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
WriteAttributeValue("", 5647, company.HomePage, 5647, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5665, 78, true);
            WriteLiteral(" class=\"dropdown-item\" target=\"_blank\">Besøg</a>\r\n                            ");
            EndContext();
            BeginContext(5743, 102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb5fb86f80b1428a81e984e8d89cc37f", async() => {
                BeginContext(5837, 4, true);
                WriteLiteral("Slet");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 99 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
                                                                           WriteLiteral(company.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5845, 32, true);
            WriteLiteral("\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5877, "\"", 5908, 2);
            WriteAttributeValue("", 5884, "tel:", 5884, 4, true);
#line 100 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
WriteAttributeValue("", 5888, company.PhoneNumber, 5888, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5909, 156, true);
            WriteLiteral(" class=\"dropdown-item\">Ring op</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 106 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#line 106 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\Index.cshtml"
     
}

#line default
#line hidden
            BeginContext(6075, 12, true);
            WriteLiteral("\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(6087, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f13dfd1082247ea8c918a281843d9f0", async() => {
                BeginContext(6169, 47, true);
                WriteLiteral("\r\n    <input id=\"Id\" type=\"hidden\" name=\"Id\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6223, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6249, 1417, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $("".sortcolumn"").each(function () {
                $(this).show();
                $(this).hover(function () {
                    $(this).css('cursor', 'pointer');
                });
                var sortAttribute = this.getAttribute(""sortcolumnname"");
                var selectedSortColumn = $(""#sortColumn"").val();
                if (sortAttribute == selectedSortColumn) {
                    var selectedSortDirection = $(""#sortDirection"").val();
                    var sortDirection = this.getAttribute(""sortdirection"");
                    if (selectedSortDirection == sortDirection) {
                        $(this).hide();
                    }
                }

            });

        });

        $("".readDetails"").click(function () {
            var companyId = this.closest('.row').getAttribute(""id"");
            $(""#Id"").val(companyId);
            $(""#companyDetails"").submit();
        });

        $(""");
                WriteLiteral(@".sortcolumn"").click(function (event) {

            var sortDirection = this.getAttribute(""sortdirection"");
            var sortColumnName = this.getAttribute(""sortcolumnname"");

            $(""#sortColumn"").val(sortColumnName);
            $(""#sortDirection"").val(sortDirection);
            $(this).hide();

            $(""#searchForm"").submit();
        });



    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
