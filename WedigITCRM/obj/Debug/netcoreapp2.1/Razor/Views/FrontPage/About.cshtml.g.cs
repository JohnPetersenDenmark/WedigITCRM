#pragma checksum "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\FrontPage\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61a3813b16f74f20b7c3b0d10ed0da3c13bac25e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FrontPage_About), @"mvc.1.0.view", @"/Views/FrontPage/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FrontPage/About.cshtml", typeof(AspNetCore.Views_FrontPage_About))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61a3813b16f74f20b7c3b0d10ed0da3c13bac25e", @"/Views/FrontPage/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_FrontPage_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\kv\projects\WedigITCRM\WedigITCRM\Views\FrontPage\About.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 32, true);
            WriteLiteral("\r\n\r\n    <html lang=\"en\">\r\n\r\n    ");
            EndContext();
            BeginContext(61, 750, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61755b9ae6764cba976167462142ecd0", async() => {
                BeginContext(67, 737, true);
                WriteLiteral(@"
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        <title>Om Nyxium</title>
        <meta name=""Description"" content=""Lær mere om vores ekstremt gode priser"">
        <script src=""https://kit.fontawesome.com/e061cad298.js"" crossorigin=""anonymous""></script>
        <link rel=""stylesheet"" href=""/frontpage/styles/scss/styles.css"">
        <link rel=""shortcut icon"" type=""image/png"" href=""/frontpage/img/favicon.png"" />
        <style>
            .top {
                background-image: url(/frontpage/img/svgs/covers/lilla-cover.svg);
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
            BeginContext(811, 992, true);
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
            BeginContext(1803, 2553, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ebe02738248457491bfebeea0fff3b4", async() => {
                BeginContext(1809, 2021, true);
                WriteLiteral(@"
            <section class=""cover_content cover_content-grid"">
                <article class=""left"">
                    <h1>Om Nyxium</h1>
                    <p class=""subheading"">
                        nyxium er udviklet af wedigIT ApS.<br /><br />
                        Vores mål er at skabe bæredygtige og billige løsninger for iværksættere og små virksomheder.<br /><br />
                        Dette vil vi ikke gøre alene. Vi vil i et samarbejde med jer skabe produkter som er udviklet af jer til jer.
                    </p>
                </article>
                <article class=""right"">
                    <img src=""/frontpage/img/svgs/om-placeholder.svg"" loading=""lazy"" class=""eheight"">
                </article>
            </section>
    </div>
    <div class=""teamWrapper container-et-eb text-center"">


        <div class=""headerh2icon"">
            <img src=""/frontpage/img/pngs/icons/chart.png"" alt=""integration-icon"" loading=""lazy"">
            <h2>Applikationer i nyxium");
                WriteLiteral(@"</h2>
        </div>

        <section class=""team grid-3"">
            <article class=""member"">
            
            </article>
            <article class=""member"">
                <p>Kundestyring (CRM)</p>
                <p>Lagerstyring</p>
                <p>Booking</p>
                <p>Leverandørstyring</p>
                <p>Salgsstatistik</p>
            </article>
            <article class=""member"">
            
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

    ");
                EndContext();
                BeginContext(3830, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c1ef0b562d046618187206b23742dd2", async() => {
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
                BeginContext(3877, 472, true);
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
            BeginContext(4356, 15, true);
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
