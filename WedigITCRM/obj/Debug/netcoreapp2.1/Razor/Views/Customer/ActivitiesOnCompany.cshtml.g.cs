#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Customer\ActivitiesOnCompany.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db4e81c6909a03ecc2edf2c5f6872199571fa6ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ActivitiesOnCompany), @"mvc.1.0.view", @"/Views/Customer/ActivitiesOnCompany.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/ActivitiesOnCompany.cshtml", typeof(AspNetCore.Views_Customer_ActivitiesOnCompany))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4e81c6909a03ecc2edf2c5f6872199571fa6ef", @"/Views/Customer/ActivitiesOnCompany.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ActivitiesOnCompany : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 7315, true);
            WriteLiteral(@"<div style=""width:90%; margin:0 auto;"">
    <table id=""companytable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
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
                <th>Tlf.</th>
                <th");
            WriteLiteral(@">Hjemmeside</th>
                <th>Ændret</th>
                <th>Oprettet</th>
            </tr>
        </tfoot>
    </table>
</div>

<br />
<br />
<div style=""width:90%; margin:0 auto;"">
    <table id=""activitytable"" class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>Id</th>
                <th>Dato</th>
                <th>Emne</th>
                <th>Beskrivelse</th>
                <th>Contact</th>
                <th>Advisering.</th>
                <th>Ændret</th>
                <th>Oprettet</th>
                <th>companyId</th>
                <th>contactPersonId</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>Id</th>
                <th>Dato</th>
                <th>Emne</th>
                <th>Beskrivelse</th>
                <th>Contact</th>
                <th>Advisering.</th>
                <th>Ændret</th>
       ");
            WriteLiteral(@"         <th>Oprettet</th>
                <th>companyId</th>
                <th>contactPersonId</th>
            </tr>
        </tfoot>
    </table>
</div>

<script>

    var activitytable;
    var activityEditor; // use a global for the submit and return data rendering in the examples
    var companyEditor; // use a global for the submit and return data rendering in the examples
    var companytable;
    var activityParentTableName = ""companytable"";
    var myAjax;
     var optionsCountries = [];
    var optionsA = [];
    var getActivitiesUrl = ""/Customer/getActivities?searchAll=0"";
    var selectedCustomerCategory;

    window.moment = moment;

    $(document).ready(function () {

        initializeCompanyEditor();
        companytable = initializeCompanyTable();

        initializeCompanyTableFooter();
        initializeSearchCompanyTableFooter();
        initializeTypeAheadInputCompanyName();
        initializeTypeAheadInputCompanyCVR();
           setPresubmitEventHandl");
            WriteLiteral(@"erOnCompanyEditor();
        setPostSubmitEventHandlerOnCompanyEditor();

        initializeActivityEditor();
        initializeActivityTable();
        initializeActivityTableFooter();
        initializeSearchActivityTableFooter();

        setRelationActivityAndCompany()

        SetStatusCreateButtonOnActivityTable(companytable);
        setListenOnSelectCompany1();
        setListenOnDeSelectSelectCompany();
        setPresubmitEventHandlerOnActivityEditor();

        setPostSubmitEventHandlerOnActivityEditor();

        var getThediv = $('#companytable_length').parent();
        var htmlStr = '<div class=""col-sm-1""><select class=""custom-select custom-select-sm form-control form-control-sm"" id=""customershowselection""><option value=""1"">Alle</option><option value=""2"">Private</option><option value=""3"">CVR-registrerede</option> </select></div>';
        $(htmlStr).insertBefore(getThediv);

        $('#customershowselection').bind('change', function () {
            selectedCustomerCatego");
            WriteLiteral(@"ry = $(this).val();
            var customerCategory = $(this).val();
            companytable.ajax.reload();
        });


        var newItem = document.createElement(""div"");       // Create a <div> node
        var textnode = document.createTextNode(""Aktiviteter"");  // Create a text node
        newItem.appendChild(textnode);
        newItem.classList.add(""tableheadline"");
        newItem.classList.add(""col-sm-2"");


        var Mydiv = document.getElementById('activitytable_wrapper');
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

        var newItem = document.createElement(""div"");       // Create a <div> ");
            WriteLiteral(@"node
        var textnode = document.createTextNode(""Kunder"");  // Create a text node
        newItem.appendChild(textnode);
        newItem.classList.add(""tableheadline"");
         newItem.classList.add(""col-sm-2"");
        

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

            activityEditor.on('opened', function (e, json, data) {
            $(""#DTE_Field_date"").datetimepicker({
                timepicker: true,
                datepicker: true,
                hours12: false,
                format: 'd-m-Y H:i'
            });

   ");
            WriteLiteral(@"           $.datetimepicker.setLocale('da');
        });

          companytable.on('xhr.dt', function (e, settings, json, xhr) {
            if (xhr.status != 200) {
                 $.fn.dataTable.ext.errMode = 'throw';  // this disables the datatables error handling
                var errorJson = xhr.responseJSON;
                var errorText = errorJson.Detail;
                var errorTitle = errorJson.Title;
                var errorInstance = errorJson.Instance;
                location.href = ""/home/ShowErrorForJSON?errorinstance="" + errorInstance;
            }
          })

          activitytable.on('xhr.dt', function (e, settings, json, xhr) {
            if (xhr.status != 200) {
                 $.fn.dataTable.ext.errMode = 'throw';  // this disables the datatables error handling
                var errorJson = xhr.responseJSON;
                var errorText = errorJson.Detail;
                var errorTitle = errorJson.Title;
                var errorInstance = errorJson.In");
            WriteLiteral("stance;\r\n                location.href = \"/home/ShowErrorForJSON?errorinstance=\" + errorInstance;\r\n            }\r\n        })\r\n    });\r\n\r\n</script> ");
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
