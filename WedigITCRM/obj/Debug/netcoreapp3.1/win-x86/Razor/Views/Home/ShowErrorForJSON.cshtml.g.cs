#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\ShowErrorForJSON.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d2b496f2032b1b235cebdd5a4846656cd18518f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowErrorForJSON), @"mvc.1.0.view", @"/Views/Home/ShowErrorForJSON.cshtml")]
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
using WedigITCRM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d2b496f2032b1b235cebdd5a4846656cd18518f", @"/Views/Home/ShowErrorForJSON.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowErrorForJSON : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""formcontainer"">

    <h2 class=""text-danger"">Ups! nyxium er løbet ind i en fejl.</h2>
    <br />
    <br />
    <br />
    <div class=""form-group row"">
        <div class=""form-group col-md-8"">
            Der er sendt en email til nyxium-support vedrørende problemet.
            <br />
            <br />
            Er du gået i stå så kontakt nyxium-support på:
            <br />
            <br />
            <br />
            Email <a");
            BeginWriteAttribute("href", " href=\"", 495, "\"", 564, 2);
            WriteAttributeValue("", 502, "mailto:support@nyxium.dk?subject=Supportkode:", 502, 45, true);
#nullable restore
#line 18 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\ShowErrorForJSON.cshtml"
WriteAttributeValue(" ", 547, Model.RequestId, 548, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Send</a>\r\n            <br />\r\n            Telefon : 7190 7153\r\n            <br />\r\n            <br />\r\n            <br />\r\n");
#nullable restore
#line 24 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\ShowErrorForJSON.cshtml"
             if (Model.ShowRequestId)

            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>\r\n                    Ved telefonisk kontakt skal du opgive support-koden vist nedenfor:\r\n                </p>\r\n                <p class=\"text-danger\">\r\n                    ");
#nullable restore
#line 31 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\ShowErrorForJSON.cshtml"
               Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>        \r\n");
#nullable restore
#line 33 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Home\ShowErrorForJSON.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
