#pragma checksum "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "247c4d7d3a2509a30d7d05d2e18199d968166ec9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContactPerson_Index), @"mvc.1.0.view", @"/Views/ContactPerson/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ContactPerson/Index.cshtml", typeof(AspNetCore.Views_ContactPerson_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 6 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.ViewControllers;

#line default
#line hidden
#line 2 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.Models;

#line default
#line hidden
#line 3 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using WedigITCRM;

#line default
#line hidden
#line 5 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#line 8 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 9 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"247c4d7d3a2509a30d7d05d2e18199d968166ec9", @"/Views/ContactPerson/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_ContactPerson_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactPersonIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "searchString", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Søgetekst"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "contactperson", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contactsDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ContactPerson", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(36, 47, true);
            WriteLiteral("\r\n\r\n<div class=\"mysearchbar\">\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(83, 2376, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d4f60efdef14021a298bacb3f9a40b4", async() => {
                BeginContext(168, 205, true);
                WriteLiteral("\r\n\r\n        <div class=\"form-row\">\r\n            <div class=\"col-3\">\r\n                <span class=\"viewHeadLine\">Kontaktpersoner</span>\r\n            </div>\r\n            <div class=\"col-2\">\r\n                ");
                EndContext();
                BeginContext(373, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1ec9a35725454486bbf1ed3674c95307", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 13 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
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
                BeginContext(485, 55, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-2\">\r\n");
                EndContext();
#line 16 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                 if (true)
                {
                    var types = new List<SelectListItem>();
                    types.Add(new SelectListItem() { Text = "Fornavn", Value = "FirstName" });
                    types.Add(new SelectListItem() { Text = "Efternavn", Value = "LastName" });
                     types.Add(new SelectListItem() { Text = "Mobil", Value = "Mobile" });
                     types.Add(new SelectListItem() { Text = "Mail", Value = "Email" });
                    types.Add(new SelectListItem() { Text = "Firmanavn", Value = "CompanyName" });

                    

#line default
#line hidden
                BeginContext(1146, 112, false);
#line 25 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
               Write(Html.DropDownList("searchBy", new SelectList(@types, "Value", "Text"), new { @class = "custom-select mr-sm-2" }));

#line default
#line hidden
                EndContext();
#line 25 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                                                                                                                     ;
                }

#line default
#line hidden
                BeginContext(1280, 305, true);
                WriteLiteral(@"            </div>
            <div class=""col-1"">
                <button type=""submit"" style=""height:36px;"" class=""btn icon-menu-background-color""><i class=""fa fa-search icon-menu-background-color"" aria-hidden=""true""></i></button>
            </div>
            <div class=""col-4"">
                ");
                EndContext();
                BeginContext(1586, 633, false);
#line 32 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
           Write(Html.PagedListPager(Model.contactPersons, page => Url.Action("Index", new { page, searchBy = Model.searchBy, searchString = Model.searchString, sortColumn = Model.sortColumn, sortDirection = Model.sortDirection }), new PagedListRenderOptions
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
                BeginContext(2219, 100, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <input id=\"sortColumn\" type=\"hidden\" name=\"sortColumn\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2319, "\"", 2344, 1);
#line 43 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
WriteAttributeValue("", 2327, Model.sortColumn, 2327, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2345, 71, true);
                WriteLiteral(">\r\n        <input id=\"sortDirection\" type=\"hidden\" name=\"sortDirection\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2416, "\"", 2444, 1);
#line 44 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
WriteAttributeValue("", 2424, Model.sortDirection, 2424, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2445, 7, true);
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
            BeginContext(2459, 2400, true);
            WriteLiteral(@"
</div>

<div class=""sortcontainer"">
    <div class=""row"">
        <div class=""col-2 columnheader"">
            Fornavn
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""FirstName"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""FirstName"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-3 columnheader"">
            Efternavn
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""LastName"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""LastName"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader");
            WriteLiteral(@""">
            Mobil
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Mobile"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Mobile"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Mail
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Email"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Email"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Firmanavn
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""CompanyName"" s");
            WriteLiteral(@"ortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""CompanyName"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>        
    </div>
    <br />
</div>


");
            EndContext();
#line 80 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
 foreach (var contactPerson in Model.contactPersons)
{

#line default
#line hidden
            BeginContext(4916, 48, true);
            WriteLiteral("<div class=\"rowcontainer\">\r\n    <div class=\"row\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4964, "\"", 5000, 1);
#line 83 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
WriteAttributeValue("", 4969, contactPerson.contactPerson.Id, 4969, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5001, 42, true);
            WriteLiteral(">\r\n        <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5044, 37, false);
#line 84 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                  Write(contactPerson.contactPerson.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(5081, 47, true);
            WriteLiteral("</div>\r\n        <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(5129, 36, false);
#line 85 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                  Write(contactPerson.contactPerson.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(5165, 47, true);
            WriteLiteral("</div>\r\n        <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5213, 37, false);
#line 86 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                  Write(contactPerson.contactPerson.CellPhone);

#line default
#line hidden
            EndContext();
            BeginContext(5250, 47, true);
            WriteLiteral("</div>\r\n        <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5298, 33, false);
#line 87 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                  Write(contactPerson.contactPerson.Email);

#line default
#line hidden
            EndContext();
            BeginContext(5331, 47, true);
            WriteLiteral("</div>\r\n        <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5379, 25, false);
#line 88 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                  Write(contactPerson.CompanyName);

#line default
#line hidden
            EndContext();
            BeginContext(5404, 241, true);
            WriteLiteral("</div>\r\n\r\n        <div class=\"col-1\">\r\n            <div class=\"dropdown\">\r\n                <div class=\"dropbtn\"><i class=\"fa fa-bars icon-menu-background-color\"></i></div>\r\n                <div class=\"dropdown-content\">\r\n                    ");
            EndContext();
            BeginContext(5645, 110, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "777dc01516484219823b533466ee7445", async() => {
                BeginContext(5744, 7, true);
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
#line 94 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                                                          WriteLiteral(contactPerson.contactPerson.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(5755, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(5777, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fd5fea1b41d430daa1d8b6e51692381", async() => {
                BeginContext(5900, 4, true);
                WriteLiteral("Slet");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 95 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
                                                                            WriteLiteral(contactPerson.contactPerson.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5908, 24, true);
            WriteLiteral("\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5932, "\"", 5981, 2);
            WriteAttributeValue("", 5939, "tel:", 5939, 4, true);
#line 96 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
WriteAttributeValue("", 5943, contactPerson.contactPerson.CellPhone, 5943, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5982, 94, true);
            WriteLiteral(">Ring op</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
#line 102 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\ContactPerson\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(6087, 10, true);
            WriteLiteral("<br />\r\n\r\n");
            EndContext();
            BeginContext(6097, 146, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad65f489f7414adba0a16a68829fb2eb", async() => {
                BeginContext(6189, 47, true);
                WriteLiteral("\r\n    <input id=\"Id\" type=\"hidden\" name=\"Id\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
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
            BeginContext(6243, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6273, 1682, true);
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
                    var co");
                WriteLiteral(@"mpanyId = this.closest('.row').getAttribute(""id"");
                    $(""#Id"").val(companyId);
                    $(""#contactsDetails"").submit();
                });

                $("".sortcolumn"").click(function (event) {

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactPersonIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
