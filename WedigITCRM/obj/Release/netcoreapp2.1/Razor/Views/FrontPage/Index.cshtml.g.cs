#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24f0d027be24b8b3d41edd820ae38c434830d8c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FrontPage_Index), @"mvc.1.0.view", @"/Views/FrontPage/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FrontPage/Index.cshtml", typeof(AspNetCore.Views_FrontPage_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24f0d027be24b8b3d41edd820ae38c434830d8c6", @"/Views/FrontPage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_FrontPage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 30, true);
            WriteLiteral("\r\n\r\n    <html lang=\"en\">\r\n    ");
            EndContext();
            BeginContext(59, 762, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "708548d828e64d508abb8fc8bb9c6513", async() => {
                BeginContext(65, 749, true);
                WriteLiteral(@"
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        <title>Velommen til nyxium</title>
        <meta name=""Description"" content=""Nyxium forbinder al din online data"">
        <script src=""https://kit.fontawesome.com/e061cad298.js"" crossorigin=""anonymous""></script>
        <link rel=""stylesheet"" href=""/frontpage/styles/scss/styles.css"">
        <link rel=""shortcut icon"" type=""image/png"" href=""/frontpage/img/favicon.png"" />
        <style>
            .top {
                background-image: url(/frontpage/img/svgs/covers/front-page-cover.svg);
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
            BeginContext(821, 992, true);
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
    <div class=""top top700"">
        ");
            EndContext();
            BeginContext(1813, 6023, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32edbfd33e4b4d3dbb8c89fd244e68d1", async() => {
                BeginContext(1819, 5503, true);
                WriteLiteral(@"
            <section class=""cover_content cover_content-grid"">
                <article class=""left"">
                    <h1 class=""fph1"">Forbind <span class=""effect""></span></h1>
                    <p class=""subheading"">
                        nyxium, er en dansk udviklet programpakke til dig som hellere vil bruge tid på din forretnings kerneprodukt. Hos os får du ikke kun en pakkeløsning som binder dine data sammen, du får den tilmed til markedets laveste pris. Fik vi nævnt... første måned er GRATIS.
                    </p>
                    <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>
                </article>
                <article class=""right"">
                    <img src=""/frontpage/img/svgs/illustrations/tabs.svg"" loading=""lazy"">
                </article>
            </section>
    </div>

    <div class=""container-et pb50"">
        <h2 class=""text-center"">Forbind din virksomhed</h2>

        <section class=""grid-3 company-connect"">
            <");
                WriteLiteral(@"article class=""company-connect_grid"">
                <img src=""/frontpage/img/svgs/illustrations/connected.svg"" loading=""lazy"">
                <h3>Sammensæt din data</h3>
                <p>
                    nyxium - en pakkeløsning<br />
                    nyxium er ikke et program men en hel programpakke. Det betyder at du ikke skal bruge tid på integrationer mellem forskellige løsninger.
                </p>
            </article>
            <article class=""company-connect_grid"">
                <img src=""/frontpage/img/svgs/illustrations/online-transactions.svg"" loading=""lazy"">
                <h3>Sammensæt din data</h3>
                <p>
                    Integration til økonomisystem<br />
                    Med nyxium vil du kunne integrere dine data med dinero og derved have en komplet og billig løsning for din virksomhed.
                </p>
            </article>
            <article class=""company-connect_grid"">
                <img src=""/frontpage/img/svgs/illustratio");
                WriteLiteral(@"ns/responsive.svg"" loading=""lazy"">
                <h3>Sammensæt din data</h3>
                <p>
                    Overfør data<br />
                    Bruger du allerede dinero, kan du med vores importmodul, let overføre dine data fra dinero til nyxium... det er selvfølgelig gratis.
                </p>
            </article>
        </section>
    </div>


    <div class=""twoGrid"">
        <section class=""container-et-eb grid-2 pb50"">
            <article class=""twoGrid_grid img1"">
                <img src=""/frontpage/img/svgs/illustrations/real-time-sync.svg"" alt="""" loading=""lazy"">
            </article>
            <article class=""twoGrid_grid text1"">
                <h2>Alle dine vigtigste data samlet et sted</h2>
                <p>Med nyxium behøver du ikke bekymre dig om dine data. Uanset hvilken del af nyxium du arbejder i, vil du have adgang til dine data på kryds og tværs. Om det er dine kunde- vare- eller leverandørinformationer så er de tilgængelige hvor de er relevante fo");
                WriteLiteral(@"r dig.</p>
                <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>
            </article>
            <article class=""twoGrid_grid text2"">
                <h2>Alle dine vigtigste data samlet et sted</h2>
                <p>
                    Med nyxium er du sikret daglig backup og en oppetid på 99,99%. Alle servere og alle data er placeret i Danmark og overholder alle regler og procedurer.
                </p>
                <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>
            </article>
            <article class=""twoGrid_grid img2"">
                <img src=""/frontpage/img/svgs/tasks.svg"" alt=""/frontpage/img/svgs/tasks.svg"" loading=""lazy"">
            </article>
        </section>
    </div>


    <div class=""container-et-eb pb50 testimonials"">

        <div class=""headerh2icon"">
            <img src=""/frontpage/img/pngs/icons/smile.png"" alt=""smile-icon"" loading=""lazy"">
            <h2>Vi vil have glade kunder</h2>
        ");
                WriteLiteral(@"</div>

        <section class=""grid-3"">
            <article class=""testimonials_grid"">
                <div class=""text"">
                    <p>
                        Vi lytter til vores kunders idéer.
                    </p>
                </div>
            </article>
            <article class=""testimonials_grid"">
                <div class=""text"">
                    <p>
                        Vi lytter til vores kunders ønsker.
                    </p>
                </div>
            </article>
            <article class=""testimonials_grid"" loading=""lazy"">
                <div class=""text"">
                    <p>
                        Vi implementerer vore kunders idéer og ønsker.
                    </p>
                </div>
            </article>
        </section>
    </div>

    <section class=""get-started container-eb text-center pb50"">

        <div class=""headerh2icon"">
            <img src=""/frontpage/img/pngs/icons/bg-rocket.png"" alt=""rocket-icon"" lo");
                WriteLiteral(@"ading=""lazy"">
            <h2>Kom i gang med at bruge Nyxium i dag</h2>
        </div>

        <p>Gratis oprettelse, gratis prøveperiode og ingen binding - Hvad skulle holde dig tilbage?</p>
        <a href=""/Account/registerCompanyAccount"" class=""btn"">Opret konto</a>
    </section>

    <script src=""https://unpkg.com/typewriter-effect@latest/dist/core.js""></script>
    ");
                EndContext();
                BeginContext(7322, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9886835cf7ef4d2d9dc646830fccf5e0", async() => {
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
                BeginContext(7369, 460, true);
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
            BeginContext(7836, 13, true);
            WriteLiteral("\r\n    </html>");
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
