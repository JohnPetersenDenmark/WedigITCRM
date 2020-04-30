#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Vendor\AllVendors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b69a501789653db682f5612e13aea44de2832ebf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendor_AllVendors), @"mvc.1.0.view", @"/Views/Vendor/AllVendors.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vendor/AllVendors.cshtml", typeof(AspNetCore.Views_Vendor_AllVendors))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b69a501789653db682f5612e13aea44de2832ebf", @"/Views/Vendor/AllVendors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Vendor_AllVendors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3208, true);
            WriteLiteral(@"

<div style=""width:90%; margin-left:0px auto;"">
    <table id=""vendortable"" class=""table table-striped table-bordered dt-responsive nowrap"" style=""width:100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>Id</th>
                <th>Navn</th>
                <th>CVR</th>
                <th>Adresse</th>
                <th>Postnr.</th>
                <th>By</th>
                <th>Land</th>
                <th>Tlf.</th>
                <th>Hjemmeside</th>
                <th>Ændret</th>
                <th>Oprettet</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
        <tfoot>
            <tr>
                <th>Id</th>
                <th>Navn</th>
                <th>CVR</th>
                <th>Adresse</th>
                <th>Postnr.</th>
                <th>By</th>
                <th>Land</th>
                <th>Tlf.</th>
                <th>Hjemmeside</th>
                <th>Ændret</th>
                <th>Oprettet");
            WriteLiteral(@"</th>
            </tr>
        </tfoot>
    </table>
</div>

<br />
<br />




<script>

    var vendortable;
    var vendorEditor; // use a global for the submit and return data rendering in the examples
    var suggestData;
    var myAjax;
    var optionsA = [];
    var optionsCountries = [];
    companyOptions = [];



    $(document).ready(function () {

        initializeVendorEditor();

        initializeVendorTable();

        initializeVendorTableFooter();
        initializeSearchVendorTableFooter();

        setPresubmitEventHandlerOnVendorEditor();

        setPostSubmitEventHandlerOnVendorEditor();

        setVendorZipDependency();

        initializeVendorNameTypeAheadInput();
        initializeTypeAheadInputVendorCVR();



        var newItem = document.createElement(""div"");       // Create a <div> node
        var textnode = document.createTextNode(""Leverandører"");  // Create a text node
        newItem.appendChild(textnode);
        newItem.class");
            WriteLiteral(@"List.add(""tableheadline"");
        newItem.classList.add(""col-sm-2"");


        var Mydiv = document.getElementById('vendortable_wrapper');
        var mychildren = Mydiv.getElementsByTagName('div');
        for (var i = 0; i < mychildren.length; ++i) {
            e = mychildren[i];
            var myclass = e.getAttribute(""class"");
            if (myclass == ""row"") {
                var mychildren1 = e.getElementsByTagName('div');
                e1 = mychildren1[0];
                e.insertBefore(newItem, e1);
                break;
            }
        }

       

        vendortable.on('xhr.dt', function (e, settings, json, xhr) {
            if (xhr.status != 200) {
                 $.fn.dataTable.ext.errMode = 'throw';  // this disables the datatables error handling
                var errorJson = xhr.responseJSON;
                var errorText = errorJson.Detail;
                var errorTitle = errorJson.Title;
                var errorInstance = errorJson.Instance;
       ");
            WriteLiteral("         location.href = \"/home/ShowErrorForJSON?errorinstance=\" + errorInstance;\r\n            }\r\n        })\r\n\r\n\r\n    });\r\n\r\n</script>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
