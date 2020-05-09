#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\Support.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "381051bf4fa0b7998e427f987d8ac3067cb9daa5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FrontPage_Support), @"mvc.1.0.view", @"/Views/FrontPage/Support.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FrontPage/Support.cshtml", typeof(AspNetCore.Views_FrontPage_Support))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"381051bf4fa0b7998e427f987d8ac3067cb9daa5", @"/Views/FrontPage/Support.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0b5aee07dbc12d92325b2fb942e71b71cc9414", @"/Views/_ViewImports.cshtml")]
    public class Views_FrontPage_Support : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\Support.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(27, 24, true);
            WriteLiteral("\r\n\r\n<html lang=\"en\">\r\n\r\n");
            EndContext();
            BeginContext(51, 768, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4dd8a35190914176b0bf62d3a93c2306", async() => {
                BeginContext(57, 755, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <title>Support - Få hjælp til vores applikation</title>
    <meta name=""Description"" content=""Har du behov for hjælp? Læs vores support, og få svar på de mest populære spørgsmål"">
    <script src=""https://kit.fontawesome.com/e061cad298.js"" crossorigin=""anonymous""></script>
    <link rel=""stylesheet"" href=""/frontpage/styles/scss/styles.css"">
    <link rel=""shortcut icon"" type=""image/png"" href=""/frontpage/img/favicon.png"" />
    <style>
        .top {
            background-image: url(/frontpage/img/svgs/covers/support-cover.svg);
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
            BeginContext(819, 900, true);
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
            BeginContext(1719, 3113, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f25bd6a8c949453bbaaaf985393edd37", async() => {
                BeginContext(1725, 2645, true);
                WriteLiteral(@"

        <section class=""cover_content cover_content-nogrid"">
            <h1>Support</h1>
            <p class=""subheading"">
                Vores supportcenter vil løbende blive opdateret. Finder du ikke hvad du søger -  så log på og skriv til os
            </p>
        </section>
</div>


<div class=""container-et-eb support pb50 text-center"">



    <div class=""headerh2icon"">
        <img src=""/frontpage/img/pngs/icons/safetyring.png"" alt="""" loading=""lazy"">
        <h2>Hvad søger du hjælp til?</h2>
    </div>

    <section class=""grid-3"">
        <article class=""support_grid"">
            <div class=""support_grid-img"">
                <img src=""/frontpage/img/pngs/icons/rocket.png"" loading=""lazy"">
            </div>
            <div class=""support_grid-text"">
                <h3>Kom godt igang</h3>
                <p>Er du ny i nyxium? Så kig med her.</p>
                <a href=""#"" class=""infolink"">Læs mere <i class=""fas fa-arrow-right""></i></a>
            </div>
        <");
                WriteLiteral(@"/article>
        <article class=""support_grid"">
            <div class=""support_grid-img"">
                <img src=""/frontpage/img/pngs/icons/integration.png"" loading=""lazy"">
            </div>
            <div class=""support_grid-text"">
                <h3>Integration til Dinero</h3>
                <p>Få hjælp til at integrere til Dinero.</p>
                <a href=""#"" class=""infolink"">Læs mere <i class=""fas fa-arrow-right""></i></a>
            </div>
        </article>
        <article class=""support_grid"">
            <div class=""support_grid-img"">
                <img src=""/frontpage/img/pngs/icons/account.png"" loading=""lazy"">
            </div>
            <div class=""support_grid-text"">
                <h3>Din konto</h3>
                <p>Har du spørgsmål til din konto. Så ring til os.</p>
                <a href=""#"" class=""infolink"">Læs mere <i class=""fas fa-arrow-right""></i></a>
            </div>
        </article>
        <article class=""support_grid"">
        </article>
");
                WriteLiteral(@"        <article class=""support_grid"">
            <div class=""support_grid-img"">
                <img src=""/frontpage/img/pngs/icons/chart.png"" loading=""lazy"">
            </div>
            <div class=""support_grid-text"">
                <h3>Betalinger</h3>
                <p>Har du spørgsmål til en betaling. Så klarer vi den over telefonen.</p>
                <a href=""#"" target=""_blank"" class=""infolink"">Læs mere <i class=""fas fa-arrow-right""></i></a>
            </div>
        </article>
        <article class=""support_grid"">
        </article>
    </section>
</div>



");
                EndContext();
                BeginContext(4370, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f859f216f0bf4ff69f3999dfce355f2b", async() => {
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
                BeginContext(4417, 408, true);
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
            BeginContext(4832, 9, true);
            WriteLiteral("\r\n</html>");
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
