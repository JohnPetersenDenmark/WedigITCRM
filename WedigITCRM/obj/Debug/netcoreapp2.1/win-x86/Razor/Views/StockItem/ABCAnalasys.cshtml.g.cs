#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\StockItem\ABCAnalasys.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69849afce34750377e30151de45090ad4ded3aab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StockItem_ABCAnalasys), @"mvc.1.0.view", @"/Views/StockItem/ABCAnalasys.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/StockItem/ABCAnalasys.cshtml", typeof(AspNetCore.Views_StockItem_ABCAnalasys))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69849afce34750377e30151de45090ad4ded3aab", @"/Views/StockItem/ABCAnalasys.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_StockItem_ABCAnalasys : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1707, true);
            WriteLiteral(@"

<div style=""width:90%; margin-left:0px auto;"">
    <table id=""abcanalasystable"" class=""table table-striped table-bordered dt-responsive nowrap"" style=""width:100%"" cellspacing=""0"">
        <thead>
            <tr>
                <th>Varenavn</th>
                <th>Varenummer</th>
                <th>Kostpris DKK</th>
                <th>Samlet antal</th>
                <th>Varens omsætning DKK</th>
                <th>% af omsætning</th>
                <th>Antal pluk</th>
                <th>% af pluk</th>
                <th>ABC omsætning</th>
                <th>ABC pluk</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
</div>

<br />
<br />

  

<script>

    var abcanalasystable;



    $(document).ready(function () {

        initializeABCAnalasysTable();

          var newItem = document.createElement(""div"");       // Create a <div> node
        var textnode = document.createTextNode(""ABC-analyse"");  // Create a text node
");
            WriteLiteral(@"        newItem.appendChild(textnode);
        newItem.classList.add(""tableheadline"");
         newItem.classList.add(""col-sm-2"");
        

        var Mydiv = document.getElementById('abcanalasystable_wrapper');
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

</script>
");
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
