#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\Integrations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1df79c27b2f60e936cad41da26f355079296073b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FrontPage_Integrations), @"mvc.1.0.view", @"/Views/FrontPage/Integrations.cshtml")]
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
#line 9 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1df79c27b2f60e936cad41da26f355079296073b", @"/Views/FrontPage/Integrations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51ba4ac1ae00931e0b6fa2532d3d0a4cf8ec236d", @"/Views/_ViewImports.cshtml")]
    public class Views_FrontPage_Integrations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/frontpage/js/front.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\FrontPage\Integrations.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    <html lang=\"en\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1df79c27b2f60e936cad41da26f355079296073b5486", async() => {
                WriteLiteral(@"
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        <title>Integrationer</title>
        <meta name=""Description"" content=""Integrationer til Nyxium"">
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
   
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1df79c27b2f60e936cad41da26f355079296073b8205", async() => {
                WriteLiteral(@"
        <div class=""top top600"">
            <section class=""cover_content cover_content-grid"">
                <article class=""left"">
                    <h1>Integrationer</h1>
                    <p class=""subheading"">
                        Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem
                        Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for
                        at trykke en
                        bog til sammenligning af forskellige skrifttyper.
                    </p>
                    <a href=""/"" class=""btn"">Opret bruger</a>
                </article>
                <article class=""right"">
                    <img src=""/frontpage/img/svgs/multiple-dinero.svg"" loading=""lazy"" class=""eheight"">
                </article>
            </section>
        </div>

        <div class=""container-et-eb pb50 integrations"">


            <div class=""headerh2icon"">
        ");
                WriteLiteral(@"        <img src=""/frontpage/img/pngs/icons/integration-bg.png"" alt=""integration-icon"" loading=""lazy"">
                <h2>Integrationer</h2>
            </div>

            <section class=""grid-3"">
                <article class=""integration_grid"">
                    <img src=""/frontpage/img/pngs/dinero.png"" loading=""lazy"">
                </article>
                <article class=""integration_grid"">
                    <img src=""/frontpage/img/pngs/dinero.png"" loading=""lazy"">
                </article>
                <article class=""integration_grid"">
                    <img src=""/frontpage/img/pngs/dinero.png"" loading=""lazy"">
                </article>
                <article class=""integration_grid"">
                    <img src=""/frontpage/img/pngs/dinero.png"" loading=""lazy"">
                </article>
                <article class=""integration_grid"">
                    <img src=""/frontpage/img/pngs/dinero.png"" loading=""lazy"">
                </article>
                <article ");
                WriteLiteral(@"class=""integration_grid"">
                    <img src=""/frontpage/img/pngs/dinero.png"" loading=""lazy"">
                </article>
            </section>
        </div>


        <div class=""twoGrid"">
            <section class=""container-et-eb grid-2 pb50"">
                <article class=""twoGrid_grid img1"">
                    <img src=""/frontpage/img/svgs/illustrations/sync.svg""");
                BeginWriteAttribute("alt", " alt=\"", 4223, "\"", 4229, 0);
                EndWriteAttribute();
                WriteLiteral(@" loading=""lazy"">
                </article>
                <article class=""twoGrid_grid text1"">
                    <h2>Alle dine vigtigste data samlet et sted</h2>
                    <p>Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper.</p>
                </article>
                <article class=""twoGrid_grid text2"">
                    <h2>Alle dine vigtigste data samlet et sted</h2>
                    <p>Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper.</p>
                </article>
                <article class=""twoGrid_grid img2"">
                    <img src=""/frontpage/img/svgs/tas");
                WriteLiteral(@"ks.svg"" alt=""/frontpage/img/svgs/tasks.svg"" loading=""lazy"">
                </article>
            </section>
        </div>

        <section class=""get-started container-eb text-center pb50"">



            <div class=""headerh2icon"">
                <img src=""/frontpage/img/pngs/icons/bg-rocket.png"" alt=""rocket-icon"" loading=""lazy"">
                <h2>Kom i gang med at bruge Nyxium i dag</h2>
            </div>

            <p>Her kan der være plads til en relevant taglinje, der lige skubber kunden det sidste stykker over rampen.</p>
            <a href=""#"" class=""btn"">Opret bruger</a>
        </section>
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1df79c27b2f60e936cad41da26f355079296073b12929", async() => {
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
                WriteLiteral(@"

        <footer>
            <div class=""columns"">


                <div class=""column"">
                    <h3>Løsninger</h3>
                    <a href=""#"">Menupunkt 1</a>
                    <a href=""#"">Menupunkt 2</a>
                    <a href=""#"">Menupunkt 3</a>
                    <a href=""#"">Menupunkt 4</a>
                </div>
                <div class=""column"">
                    <h3>Support</h3>
                    <a href=""#"">Menupunkt 1</a>
                    <a href=""#"">Menupunkt 2</a>
                    <a href=""#"">Menupunkt 3</a>
                    <a href=""#"">Menupunkt 4</a>
                </div>
                <div class=""column"">
                    <h3>Nyxium</h3>
                    <a href=""#"">Menupunkt 1</a>
                    <a href=""#"">Menupunkt 2</a>
                    <a href=""#"">Menupunkt 3</a>
                    <a href=""#"">Menupunkt 4</a>
                </div>

                <div class=""column"">
                    <a href=""#"">FB");
                WriteLiteral("</a>\r\n                    <a href=\"#\">LN</a>\r\n                    <a href=\"#\">IG</a>\r\n                </div>\r\n            </div>\r\n        </footer>\r\n\r\n\r\n    ");
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
            WriteLiteral("\r\n\r\n    </html>");
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