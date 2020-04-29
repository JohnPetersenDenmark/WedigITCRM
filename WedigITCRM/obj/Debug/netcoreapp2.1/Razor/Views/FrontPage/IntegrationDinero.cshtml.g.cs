#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\IntegrationDinero.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfbffa255c45942fef8ded86e6a6de4b411b44da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FrontPage_IntegrationDinero), @"mvc.1.0.view", @"/Views/FrontPage/IntegrationDinero.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FrontPage/IntegrationDinero.cshtml", typeof(AspNetCore.Views_FrontPage_IntegrationDinero))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfbffa255c45942fef8ded86e6a6de4b411b44da", @"/Views/FrontPage/IntegrationDinero.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_FrontPage_IntegrationDinero : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/frontpage/js/front.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\IntegrationDinero.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(27, 30, true);
            WriteLiteral("\r\n    <html lang=\"en\">\r\n\r\n    ");
            EndContext();
            BeginContext(57, 748, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03613c882e984ef8b3edf654b1f73621", async() => {
                BeginContext(63, 735, true);
                WriteLiteral(@"
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        <title>Dinero integration</title>
        <meta name=""Description"" content=""Dinero integration"">
        <script src=""https://kit.fontawesome.com/e061cad298.js"" crossorigin=""anonymous""></script>
        <link rel=""stylesheet"" href=""/frontpage/styles/scss/styles.css"">
        <link rel=""shortcut icon"" type=""image/png"" href=""/frontpage/img/favicon.png"" />
        <style>

            .top {
                background-image: url(/frontpage/img/svgs/covers/integrations-cover.svg);
                background-size: cover;
                background-position: bottom;
            }
        </style>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(805, 992, true);
            WriteLiteral(@"

    <header>
        <div class=""header-wrapper"">
            <div class=""logo""><a href=""/""><img src=""/frontpage/img/nyxium-logo.png""></a></div>
            <div class=""burger"">
                <span class=""bars""></span>
            </div>
            <nav class=""nav"">
                <a href=""/frontpage/prices"">Priser</a>
                <div class=""submenu"">
                    <p class=""dropdowntrigger"">Integrationer <i class=""fas fa-chevron-down""></i></p>
                    <div class=""submenubullets"">
                        <a href=""/frontpage/integrationdinero"">Dinero</a>
                    </div>
                </div>
                <a href=""/frontpage/About"">Om</a>
                <a href=""/frontpage/support"">Support</a>
                <a href=""/Account/login"">Login</a>
                <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>
            </nav>
        </div>
    </header>
    <div class=""top top600"">
        ");
            EndContext();
            BeginContext(1797, 3251, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2295f81df24d493db563bf5df0b70898", async() => {
                BeginContext(1803, 2727, true);
                WriteLiteral(@"
            <section class=""cover_content cover_content-grid"">
                <article class=""left"">
                    <h1>Integration til Dinero</h1>
                    <p class=""subheading"">
                        Hvis du har eller vælger Dinero som dit regnskabsprogram sikrer nyxium at der er sammenhæng i dine data og dermed i din forretning.
                    </p>
                    <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>

                </article>
                <article class=""right"">
                    <img src=""/frontpage/img/svgs/dinero-l-logo.svg"" loading=""lazy"" class=""eheight"">
                </article>
            </section>
    </div>

    <div class=""twoGrid"">
        <section class=""container-et-eb grid-2 pb50"">
            <article class=""twoGrid_grid img1"">
                <img src=""/frontpage/img/svgs/illustrations/progessive-app.svg"" alt="""" loading=""lazy"">
            </article>
            <article class=""twoGrid_grid text1"">");
                WriteLiteral(@"
                <h2>Sammenhæng i din forretning</h2>
                <p>
                    Hvis du bruger Dineros regnskabsprogram, kan du med applikationerne i nyxium knytte funktioner til dit regnskabsprogram. Dette er med til at gøre dine arbejdsgange lettere og mere brugervenlige. Helt afhængigt af din virksomheds art er der forskellige applikationer du kan anvende i nyxium.
                </p>
            </article>
            <article class=""twoGrid_grid text2"">
                <h2>Eksempler på sammenhænge</h2>
                <p>
                - Salgsstatistik genereres fra nyxiums lagerstyring som trækker varelinjer ud af fakturarerne i Dinero.<br />
                - Kunder i nyxiums kundetyringsmodul overføres automatisk til Dinero<br />
                - Produkter i nyxiums lagerstyring overføres automatisk til Dinero<br />
                </p>
            </article>
            <article class=""twoGrid_grid img2"">
                <img src=""/frontpage/img/svgs/tasks.svg"" alt=""/f");
                WriteLiteral(@"rontpage/img/svgs/tasks.svg"" loading=""lazy"">
            </article>
        </section>
    </div>


    <section class=""get-started container-eb text-center pb50"">



        <div class=""headerh2icon"">
            <img src=""/frontpage/img/pngs/icons/bg-rocket.png"" alt=""rocket-icon"" loading=""lazy"">
            <h2>Kom i gang med at bruge Nyxium i dag</h2>
        </div>

        <p>Gratis oprettelse, gratis prøveperiode og ingen binding - Hvad skulle holde dig tilbage?</p>
        <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>
    </section>
    <script src=""https://unpkg.com/typewriter-effect@latest/dist/core.js""></script>

    ");
                EndContext();
                BeginContext(4530, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e86e226390c3442da0ff67bf821ee15b", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4577, 464, true);
                WriteLiteral(@"

    <footer>
        <div class=""columns"">


            <div class=""column"">

                <a href=""#"">
                    nyxium er ejet og drevet af:<br />
                    wedigIT ApS<br />
                    Axeltorv 5 3 2<br />
                    4700 Næstved<br />
                    CVR: 40777326<br />
                    info@nyxium.dk<br />
                </a>

            </div>

        </div>
    </footer>


    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5048, 15, true);
            WriteLiteral("\r\n\r\n    </html>");
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
