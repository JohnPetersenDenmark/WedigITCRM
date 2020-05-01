#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Customer\AllCustomers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "375ae43d87737b7ca0694801253576c603ccdef3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_AllCustomers), @"mvc.1.0.view", @"/Views/Customer/AllCustomers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/AllCustomers.cshtml", typeof(AspNetCore.Views_Customer_AllCustomers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375ae43d87737b7ca0694801253576c603ccdef3", @"/Views/Customer/AllCustomers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_AllCustomers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3635, true);
            WriteLiteral(@"<div style=""width:90%; margin:0px auto;"">
    <table id=""companytable"" class=""table table-striped table-bordered dt-responsive nowrap"" style=""width:100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>Id</th>
                <th>Navn</th>
                <th>Privat</th>
                <th>Email</th>
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
                <th>Privat</th>
                <th>Email</th>
                <th>CVR</th>
                <th>Adresse</th>
                <th>Postnr.</th>
                <th>By</th>
                <th>Land</th>
       ");
            WriteLiteral(@"         <th>Tlf.</th>
                <th>Hjemmeside</th>
                <th>Ændret</th>
                <th>Oprettet</th>
            </tr>
        </tfoot>
    </table>
</div>

<br />
<br />




<script>

    var companytable;
    var companyEditor; // use a global for the submit and return data rendering in the examples
    var suggestData;
    var myAjax;
    var optionsA = [];
    var optionsCountries = [];
    companyOptions = [];
    var Myurl = ""/Customer/getContactPersons""
    var selectedCustomerCategory;


    $(document).ready(function () {


        initializeCompanyEditor();

        companytable = initializeCompanyTable();

        initializeCompanyTableFooter();
        initializeSearchCompanyTableFooter();

        setPresubmitEventHandlerOnCompanyEditor();

        setPostsubmitEventHandlerOnCompanyEditor();

        setZipDependency();

        companytable.columns.adjust();

        initializeTypeAheadInputCompanyName();
        initializeTy");
            WriteLiteral(@"peAheadInputCompanyCVR();



        var getThediv = $('#companytable_length').parent();
        var htmlStr = '<div class=""col-sm-1""><select class=""custom-select custom-select-sm form-control form-control-sm"" id=""customershowselection""><option value=""1"">Alle</option><option value=""2"">Private</option><option value=""3"">CVR-registrerede</option> </select></div>';
        $(htmlStr).insertBefore(getThediv);

        $('#customershowselection').bind('change', function () {
            selectedCustomerCategory = $(this).val();
            var customerCategory = $(this).val();
            companytable.ajax.reload();
        });


        $('#companytable')
            .on('xhr.dt', function (e, settings, json, xhr) {

            })


        var newItem = document.createElement(""div"");       // Create a <div> node
        var textnode = document.createTextNode(""Kunder"");  // Create a text node
        newItem.appendChild(textnode);
        newItem.classList.add(""tableheadline"");
        ne");
            WriteLiteral(@"wItem.classList.add(""col-sm-2"");


        var Mydiv = document.getElementById('companytable_wrapper');
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
    });
</script>");
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
