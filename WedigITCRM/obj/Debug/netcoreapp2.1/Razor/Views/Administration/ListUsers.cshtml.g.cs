#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e1508bea84f18ad97cd046624a0fde08c8986ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_ListUsers), @"mvc.1.0.view", @"/Views/Administration/ListUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administration/ListUsers.cshtml", typeof(AspNetCore.Views_Administration_ListUsers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e1508bea84f18ad97cd046624a0fde08c8986ca", @"/Views/Administration/ListUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_ListUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListUsersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "searchString", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Søgetekst"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListUsers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ManageUserRoles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("UseridForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(27, 45, true);
            WriteLiteral("\r\n<div class=\"mysearchbar\">\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(72, 2276, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e81faca429f4e5dab17e51539d270aa", async() => {
                BeginContext(162, 197, true);
                WriteLiteral("\r\n\r\n        <div class=\"form-row\">\r\n            <div class=\"col-2\">\r\n                <span class=\"viewHeadLine\">Brugere</span>\r\n            </div>\r\n            <div class=\"col-2\">\r\n                ");
                EndContext();
                BeginContext(359, 112, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f4971414a2184c27bd854d54973d2510", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 12 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
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
                BeginContext(471, 55, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-2\">\r\n");
                EndContext();
#line 15 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                 if (true)
                {
                    var types = new List<SelectListItem>();
                      types.Add(new SelectListItem() { Text = "Navn", Value = "Name" });
                    types.Add(new SelectListItem() { Text = "Brugernavn", Value = "UserName" });
                    types.Add(new SelectListItem() { Text = "Mail", Value = "Email" });
                    types.Add(new SelectListItem() { Text = "BrugerId", Value = "UserId" });                  
                    

#line default
#line hidden
                BeginContext(1044, 112, false);
#line 22 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
               Write(Html.DropDownList("searchBy", new SelectList(@types, "Value", "Text"), new { @class = "custom-select mr-sm-2" }));

#line default
#line hidden
                EndContext();
#line 22 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                                                                                                                     ;
                }

#line default
#line hidden
                BeginContext(1178, 305, true);
                WriteLiteral(@"            </div>
            <div class=""col-1"">
                <button type=""submit"" style=""height:36px;"" class=""btn icon-menu-background-color""><i class=""fa fa-search icon-menu-background-color"" aria-hidden=""true""></i></button>
            </div>
            <div class=""col-4"">
                ");
                EndContext();
                BeginContext(1484, 624, false);
#line 29 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
           Write(Html.PagedListPager(Model.users, page => Url.Action("Index", new { page, searchBy = Model.searchBy, searchString = Model.searchString, sortColumn = Model.sortColumn, sortDirection = Model.sortDirection }), new PagedListRenderOptions
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
                BeginContext(2108, 100, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <input id=\"sortColumn\" type=\"hidden\" name=\"sortColumn\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2208, "\"", 2233, 1);
#line 40 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
WriteAttributeValue("", 2216, Model.sortColumn, 2216, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2234, 71, true);
                WriteLiteral(">\r\n        <input id=\"sortDirection\" type=\"hidden\" name=\"sortDirection\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2305, "\"", 2333, 1);
#line 41 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
WriteAttributeValue("", 2313, Model.sortDirection, 2313, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2334, 7, true);
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
            BeginContext(2348, 1933, true);
            WriteLiteral(@"
</div>

<br />


<div class=""sortcontainer"">
    <div class=""row"">
        <div class=""col-3 columnheader"">
            Navn
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Name"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Name"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-3 columnheader"">
            Brugernavn
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""UserName"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""UserName"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-3 columnheader");
            WriteLiteral(@""">
            Email
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Email"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""Email"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
        <div class=""col-3 columnheader"">
            Bruger Id.
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""UserId"" sortdirection=""Ascending""><i class=""fa fa-arrow-circle-o-down"" aria-hidden=""true""></i></span>
            <span class=""sortcolumn icon-menu-background-color"" sortcolumnname=""UserId"" sortdirection=""Descending""><i class=""fa fa-arrow-circle-o-up sortcolumn"" aria-hidden=""true""></i></span>
        </div>
    </div>
    <br />
</div>



");
            EndContext();
#line 76 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
 foreach (var user in Model.users)
{

#line default
#line hidden
            BeginContext(4320, 56, true);
            WriteLiteral("    <div class=\"rowcontainer\">\r\n        <div class=\"row\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4376, "\"", 4394, 1);
#line 79 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
WriteAttributeValue("", 4381, user.User.Id, 4381, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4395, 46, true);
            WriteLiteral(">\r\n            <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(4442, 13, false);
#line 80 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                      Write(user.userName);

#line default
#line hidden
            EndContext();
            BeginContext(4455, 51, true);
            WriteLiteral("</div>\r\n            <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(4507, 18, false);
#line 81 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                      Write(user.User.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(4525, 51, true);
            WriteLiteral("</div>\r\n            <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(4577, 15, false);
#line 82 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                      Write(user.User.Email);

#line default
#line hidden
            EndContext();
            BeginContext(4592, 51, true);
            WriteLiteral("</div>\r\n            <div class=\"col-3 readDetails\">");
            EndContext();
            BeginContext(4644, 12, false);
#line 83 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                      Write(user.User.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4656, 259, true);
            WriteLiteral(@"</div>
            <div class=""col-1"">
                <div class=""dropdown"">
                    <div class=""dropbtn""><i class=""fa fa-bars icon-menu-background-color""></i></div>
                    <div class=""dropdown-content"">
                        ");
            EndContext();
            BeginContext(4915, 167, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7110395c8b714ef3aada5af3b77dcb42", async() => {
                BeginContext(5053, 25, true);
                WriteLiteral("Administrer brugerrolller");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                                                                              WriteLiteral(user.User.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5082, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5108, 138, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8e6e6121a344c7690f0fba78d43d67c", async() => {
                BeginContext(5235, 7, true);
                WriteLiteral("Rediger");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 89 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                                                                   WriteLiteral(user.User.Id);

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
            BeginContext(5246, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5272, 137, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2061971220b47e199065581c87397a7", async() => {
                BeginContext(5401, 4, true);
                WriteLiteral("Slet");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 90 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
                                                                                     WriteLiteral(user.User.Id);

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
            BeginContext(5409, 102, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 96 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Administration\ListUsers.cshtml"
}

#line default
#line hidden
            BeginContext(5514, 12, true);
            WriteLiteral("\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(5526, 146, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e3bd2328718446389b386b9077b9033", async() => {
                BeginContext(5618, 47, true);
                WriteLiteral("\r\n    <input id=\"Id\" type=\"hidden\" name=\"Id\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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
            BeginContext(5672, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5699, 1425, true);
                WriteLiteral(@"
    <script>
          $(document).ready(function () {
            $("".sortcolumn"").each(function () {
                $(this).show();
                  $(this).hover(function() {
                        $(this).css('cursor','pointer');
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

          $("".sortcolumn"").click(function (event) {

            var sortDirection = this.getAttribute(""sortdirection"");
            var sortColumnName = this.getAttribute(""sortcolumnname"");

      ");
                WriteLiteral(@"      $(""#sortColumn"").val(sortColumnName);
            $(""#sortDirection"").val(sortDirection);
            $(this).hide();

            $(""#searchForm"").submit();
        });

        $("".readDetails"").click(function () {
            var userId = this.closest('.row').getAttribute(""id"");
            $(""#Id"").val(userId);
            $(""#UseridForm"").submit();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListUsersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
