#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\BuyLicense.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0f1f37e558bdc1af3fe7c2d691299e72c0cd3f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FrontPage_BuyLicense), @"mvc.1.0.view", @"/Views/FrontPage/BuyLicense.cshtml")]
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
#line 11 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0f1f37e558bdc1af3fe7c2d691299e72c0cd3f1", @"/Views/FrontPage/BuyLicense.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"642d61d8ed407df9587058297a864dd310c67be2", @"/Views/_ViewImports.cshtml")]
    public class Views_FrontPage_BuyLicense : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WedigITCRM.Controllers.AccountController.LicenseSelectionModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ActivationKey"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\BuyLicense.cshtml"
  
    Layout = "_LayoutAnonymousMenu";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
   
        <div class=""top "">
            <section class=""cover_content cover_content-nogrid"">

                <h1> Din gratis periode er udløbet.</h1>
                <p class=""subheading"">
                    Hvis du ønsker at forsætte så vælg et abonnement nedenfor. Hvis du ikke ønsker et abonnement, gemmer vi dine data 1 måned. Herefter vil dine data blive slettet.
                </p>


                <article class=""price"">
                    <div class=""price-box"">
                        <p class=""type"">Basis</p>
                        <p class=""pprice"">49 DKK</p>
                        <p class=""pprice"">excl. moms pr. md.</p>
                        <p class=""description"">Perfekt til dem der vil se nyxium an</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-green.jpg"">Gratis oprettelse</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-green.jpg"">Ubegrænset antal brugere</p>
                    ");
            WriteLiteral(@"    <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-green.jpg"">1 applikation</p>

                        <p class=""features""><input type=""checkbox"" id=""licenseCRM"" class=""basic""> CRM/Kundestyring</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseVendors"" class=""basic""> Leverandører</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseInventory"" class=""basic""> Lagerstyring</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseStatistic"" class=""basic""> Salgsstatistik</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseBooking"" class=""basic""> Booking</p>

                        <a href=""#"" id=""buttonbasicSelected"" class=""btn btn-fullwidth"">Køb</a>
                        <p id=""errorbasicSelecton"" style=""color:red;"" class=""description""></p>
                    </div>
                    <div class=""price-box"">
                        <p class=""type blue"">Pro</p>
   ");
            WriteLiteral(@"                     <p class=""pprice"">79 DKK</p>
                        <p class=""pprice"">excl. moms pr. md.</p>
                        <p class=""description"">Perfekt til den mindre forretning</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-blue.jpg"">Gratis oprettelse</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-blue.jpg"">Ubegrænset antal brugere</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-blue.jpg"">3 applikationer</p>

                        <p class=""features""><input type=""checkbox"" id=""licenseCRM"" class=""pro""> CRM/Kundestyring</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseVendors"" class=""pro""> Leverandører</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseInventory"" class=""pro""> Lagerstyring</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseStatistic"" class=""pr");
            WriteLiteral(@"o""> Salgsstatistik</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseBooking"" class=""pro""> Booking</p>

                        <a href=""#"" id=""buttonproSelected"" class=""btn btn-fullwidth blue-bg"">Køb</a>
                        <p id=""errorproSelecton"" style=""color:red;"" class=""description""></p>


                    </div>
                    <div class=""price-box"">
                        <p class=""type purple"">Business</p>
                        <p class=""pprice"">99 DKK</p>
                        <p class=""pprice"">excl. moms pr. md.</p>
                        <p class=""description"">Perfekt til den lidt større forretning</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-purple.jpg"">Gratis oprettelse</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-purple.jpg"">Ubegrænset antal brugere</p>
                        <p class=""features""><img src=""/frontpage/img/jpgs/price-circle-pu");
            WriteLiteral(@"rple.jpg"">Alle applikationer</p>

                        <p class=""features""><input type=""checkbox"" id=""licenseCRM"" class=""business"" checked disabled> CRM/Kundestyring</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseVendors"" class=""business"" checked disabled> Leverandører</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseInventory"" class=""business"" checked disabled> Lagerstyring</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseStatistic"" class=""business"" checked disabled> Salgsstatistik</p>
                        <p class=""features""><input type=""checkbox"" id=""licenseBooking"" class=""business"" checked disabled> Booking</p>

                        <a href=""#"" id=""buttonbusinessSelected"" class=""btn btn-fullwidth purple-bg"">Køb</a>
                    </div>
                </article>

            </section>

            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a0f1f37e558bdc1af3fe7c2d691299e72c0cd3f111096", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 78 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\BuyLicense.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.ActivationKey);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>





        <section class=""integrations-overview container-et-eb text-center"">
        </section>


        <div class=""container-et-eb pb50 testimonials"">



        </div>


     

       


    <script>

        $(document).ready(function () {


            $('.basic').bind('change', function () {

                var flag = $(this).prop('checked');
                var currentCheckBox = $(this);

                $("".basic"").each(function (index) {
                    $(this).prop(""checked"", false);
                });

                if (flag) {
                    currentCheckBox.prop(""checked"", true);
                }
            });

            // Basic license i selected

            $('#buttonbasicSelected').bind('click', function () {

                var IsAnySelected = false;

                var selectedApp;

                $("".basic"").each(function (index) {

                    if ($(this).prop(""checked"")) {
             ");
            WriteLiteral(@"           IsAnySelected = true;
                        selectedApp = $(this).attr(""id"")
                    }
                });

                if (IsAnySelected == false) {
                    $('#errorbasicSelecton').html(""Der skal vælges en applikation"");
                }
                else {
                    $('#errorbasicSelecton').html("""");
                    submitLicenseSelection(""Basic"", selectedApp);
                }
            });

            // Pro license i selected

            $('#buttonproSelected').bind('click', function () {

                var numberOfSelectedApps = 0;

                var selectedAppIds = [];

                $("".pro"").each(function (index) {

                    if ($(this).prop(""checked"")) {
                        numberOfSelectedApps++;
                        selectedAppIds.push($(this).attr(""id""));
                    }
                });


                if (numberOfSelectedApps == 0) {
                    $('#errorp");
            WriteLiteral(@"roSelecton').html(""Der er ikke valgt nogle applikationer"");
                    return;
                }
                if (numberOfSelectedApps != 3) {
                    $('#errorproSelecton').html(""Der skal vælges 3 applikationer"");
                    return;
                }
                else {
                    $('#errorproSelecton').html("""");
                    submitLicenseSelection(""Pro"", selectedAppIds.toString());
                }
            });

            // Business license i selected

            $('#buttonbusinessSelected').bind('click', function () {
                submitLicenseSelection(""Business"", selectedApp);
            });

        });




        function submitLicenseSelection(licenseType, Applications) {


            var activationKey = $('#ActivationKey').val();

            $.ajax({
                type: ""POST"",
                url: ""/account/BuyLicense"",
                data: 'licenseType=' + licenseType + ""&applications="" + Applicati");
            WriteLiteral(@"ons + ""&ActivationKey="" + activationKey,
                contentType: ""application/x-www-form-urlencoded; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {


                },

                failure: function (errMsg) {
                    alert(errMsg);
                }
            });


        }

    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WedigITCRM.Controllers.AccountController.LicenseSelectionModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
