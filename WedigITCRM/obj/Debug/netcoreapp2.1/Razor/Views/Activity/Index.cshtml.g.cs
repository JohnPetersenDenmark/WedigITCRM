#pragma checksum "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a044bd238303440c38889e30a1dfb1d396a066c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_Index), @"mvc.1.0.view", @"/Views/Activity/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Activity/Index.cshtml", typeof(AspNetCore.Views_Activity_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a044bd238303440c38889e30a1dfb1d396a066c2", @"/Views/Activity/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ActivityIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "searchString", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Søgetekst"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "activity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("activityDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Activity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(31, 47, true);
            WriteLiteral("\r\n\r\n<div class=\"mysearchbar\">\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(78, 2268, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61338feb5ccb4a78bdcdda91522fece2", async() => {
                BeginContext(158, 88, true);
                WriteLiteral("\r\n\r\n        <div class=\"form-row\">\r\n            <div class=\"col-auto\">\r\n                ");
                EndContext();
                BeginContext(246, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f4855e6ef28d4941b6e9d428124b8e46", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 10 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
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
                BeginContext(358, 58, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-auto\">\r\n");
                EndContext();
#line 13 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                 if (true)
                {
                    var types = new List<SelectListItem>();
                    types.Add(new SelectListItem() { Text = "Emne", Value = "Subject" });
                    types.Add(new SelectListItem() { Text = "Dato", Value = "Date" });
                    types.Add(new SelectListItem() { Text = "Beskrivelse", Value = "Description" });
                    types.Add(new SelectListItem() { Text = "Firma", Value = "CompanyName" });
                    types.Add(new SelectListItem() { Text = "Kontaktperson", Value = "ContactPersonName" });

                    

#line default
#line hidden
                BeginContext(1034, 112, false);
#line 22 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
               Write(Html.DropDownList("searchBy", new SelectList(@types, "Value", "Text"), new { @class = "custom-select mr-sm-2" }));

#line default
#line hidden
                EndContext();
#line 22 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                                                                                                                     ;
                }

#line default
#line hidden
                BeginContext(1168, 308, true);
                WriteLiteral(@"            </div>
            <div class=""col-auto"">
                <button type=""submit"" style=""height:36px;"" class=""btn icon-menu-background-color""><i class=""fa fa-search icon-menu-background-color"" aria-hidden=""true""></i></button>
            </div>
            <div class=""col-4"">
                ");
                EndContext();
                BeginContext(1477, 629, false);
#line 29 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
           Write(Html.PagedListPager(Model.activities, page => Url.Action("Index", new { page, searchBy = Model.searchBy, searchString = Model.searchString, sortColumn = Model.sortColumn, sortDirection = Model.sortDirection }), new PagedListRenderOptions
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
                BeginContext(2106, 100, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <input id=\"sortColumn\" type=\"hidden\" name=\"sortColumn\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2206, "\"", 2231, 1);
#line 40 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
WriteAttributeValue("", 2214, Model.sortColumn, 2214, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2232, 71, true);
                WriteLiteral(">\r\n        <input id=\"sortDirection\" type=\"hidden\" name=\"sortDirection\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2303, "\"", 2331, 1);
#line 41 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
WriteAttributeValue("", 2311, Model.sortDirection, 2311, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2332, 7, true);
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
            BeginContext(2346, 2486, true);
            WriteLiteral(@"
</div>



<div class=""sortcontainer"">
    <div class=""row"">
        <div class=""col-2 columnheader"">
            Dato
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Date"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Date"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Emne
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Subject"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Subject"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-3 columnheader"">
            ");
            WriteLiteral(@"Beskrivelse.
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Description"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Description"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Firma
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""CompanyName"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""CompanyName"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-2 columnheader"">
            Kontaktperson
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnna");
            WriteLiteral(@"me=""ContactPersonName"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""ContactPersonName"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-1 columnheader"">
        </div>
    </div>
    <br />
</div>





");
            EndContext();
#line 84 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
 foreach (var activity in Model.activities)
{

#line default
#line hidden
            BeginContext(4880, 56, true);
            WriteLiteral("    <div class=\"rowcontainer\">\r\n        <div class=\"row\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4936, "\"", 4962, 1);
#line 87 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
WriteAttributeValue("", 4941, activity.activity.Id, 4941, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4963, 46, true);
            WriteLiteral(">\r\n            <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5010, 22, false);
#line 88 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                      Write(activity.activity.Date);

#line default
#line hidden
            EndContext();
            BeginContext(5032, 51, true);
            WriteLiteral("</div>\r\n            <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5084, 25, false);
#line 89 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                      Write(activity.activity.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(5109, 51, true);
            WriteLiteral("</div>\r\n            <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(5161, 29, false);
#line 90 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                      Write(activity.activity.Description);

#line default
#line hidden
            EndContext();
            BeginContext(5190, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 91 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
             if (activity.company != null)
            {

#line default
#line hidden
            BeginContext(5257, 47, true);
            WriteLiteral("                <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5305, 21, false);
#line 93 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                          Write(activity.company.Name);

#line default
#line hidden
            EndContext();
            BeginContext(5326, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 94 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(5382, 55, true);
            WriteLiteral("                <div class=\"col-2 readDetails\"></div>\r\n");
            EndContext();
#line 98 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(5452, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 99 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
             if (activity.contactPerson != null)
            {

#line default
#line hidden
            BeginContext(5517, 47, true);
            WriteLiteral("                <div class=\"col-2 readDetails\">");
            EndContext();
            BeginContext(5565, 32, false);
#line 101 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                          Write(activity.contactPerson.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(5597, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(5599, 31, false);
#line 101 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                                                            Write(activity.contactPerson.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(5630, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 102 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(5686, 55, true);
            WriteLiteral("                <div class=\"col-2 readDetails\"></div>\r\n");
            EndContext();
#line 106 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(5756, 253, true);
            WriteLiteral("\r\n            <div class=\"col-1\">\r\n                <div class=\"dropdown\">\r\n                    <div class=\"dropbtn\"><i class=\"fa fa-bars icon-menu-background-color\"></i></div>\r\n                    <div class=\"dropdown-content\">\r\n                        ");
            EndContext();
            BeginContext(6009, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39049fd1c0d247eba3ea9adc6c19eb95", async() => {
                BeginContext(6093, 7, true);
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
#line 112 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                                                         WriteLiteral(activity.activity.Id);

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
            BeginContext(6104, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(6130, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8583a47ab287451087b6f32d89a9b60d", async() => {
                BeginContext(6216, 4, true);
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
#line 113 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                                                                           WriteLiteral(activity.activity.Id);

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
            BeginContext(6224, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 114 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                         if (activity.company != null)
                        {

#line default
#line hidden
            BeginContext(6309, 30, true);
            WriteLiteral("                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6339, "\"", 6379, 2);
            WriteAttributeValue("", 6346, "tel:", 6346, 4, true);
#line 116 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
WriteAttributeValue("", 6350, activity.company.PhoneNumber, 6350, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6380, 36, true);
            WriteLiteral(" class=\"dropdown-item\">Ring op</a>\r\n");
            EndContext();
#line 117 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(6443, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 118 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                         if (activity.contactPerson != null)
                        {

#line default
#line hidden
            BeginContext(6532, 30, true);
            WriteLiteral("                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6562, "\"", 6606, 2);
            WriteAttributeValue("", 6569, "tel:", 6569, 4, true);
#line 120 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
WriteAttributeValue("", 6573, activity.contactPerson.CellPhone, 6573, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6607, 36, true);
            WriteLiteral(" class=\"dropdown-item\">Ring op</a>\r\n");
            EndContext();
#line 121 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(6670, 104, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 129 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\Activity\Index.cshtml"

}

#line default
#line hidden
            BeginContext(6779, 12, true);
            WriteLiteral("\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(6791, 141, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c985e8e2faa24e4aaec8e97400158fd1", async() => {
                BeginContext(6878, 47, true);
                WriteLiteral("\r\n    <input id=\"Id\" type=\"hidden\" name=\"Id\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
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
            BeginContext(6932, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6954, 1477, true);
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

            $('body').on('click', '.readDetails', function (e) {
                   var activityId = this.closest('.row').getAttribute(""id"");
                    $(""#Id"").val(activityId);
                    $(""#activityDetails"").submit(");
                WriteLiteral(@");
            });


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ActivityIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
