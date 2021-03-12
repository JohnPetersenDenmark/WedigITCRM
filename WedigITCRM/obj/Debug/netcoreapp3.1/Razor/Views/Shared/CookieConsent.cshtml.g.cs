#pragma checksum "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Shared\CookieConsent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd58efe5939edd31f909c9ea642402a6df259c4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CookieConsent), @"mvc.1.0.view", @"/Views/Shared/CookieConsent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd58efe5939edd31f909c9ea642402a6df259c4d", @"/Views/Shared/CookieConsent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fc04a0290131b0b832d4c5c3a26c71284940263", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CookieConsent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/account/CookieSettings"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("cookiesettings"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Shared\CookieConsent.cshtml"
  

    bool HasUserConsented = false;

    foreach (var cookie in HttpContextAccessor.HttpContext.Request.Cookies.Keys)
    {
        string cookieName = cookie;
        if (cookieName.Equals("nyxium_consent"))
        {
            HasUserConsented = true;
        }
        string cookieValue = HttpContextAccessor.HttpContext.Request.Cookies[cookieName];

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 23 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Shared\CookieConsent.cshtml"
 if (!HasUserConsented)
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""consent-chapter"">
        <div class=""consent-headline"">
            <p>Vi bruger cookies til at markedsføre nyxium.</p>
        </div>
        <p>
            Hvis du klikker på knappen ’Accepter’, godkender du, at nyxium sætter
            cookies til brug for markedsføring.
        </p>
        <p>
            Hvis du klikker på knappen ’Afslå,’ sætter vi ikke cookies til brug for
            markedsføring
        </p>
        <p>
            Dit valg bliver gemt i en cookie.
        </p>
        <p>
            Her kan du se hvilke cookier som nyxium anvender til markedsføring
        </p>
    </section>
");
            WriteLiteral(@"    <div class=""card"">
        <div class=""card-header"">
            <div class=""card-body"">
                <a href=""#"" id=""consent"" class=""btn btn-primary consent-btn"">Accepter</a>
                <a href=""#"" id=""noconsent"" class=""btn btn-primary no-consent-btn"">Afslå</a>
            </div>
        </div>
    </div>
");
            WriteLiteral("    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n");
            WriteLiteral(@"    <article class=""cookie-description"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-3"">
                    <div class=""sidebar-item"">
                        <div class=""make-me-sticky"">
                            <p class=""cookie-menu""><a href=""#a1"">Hvad er cookies</a></p>
                            <p class=""cookie-menu""><a href=""#a2"">nyxium cookies</a></p>
                            <p class=""cookie-menu""><a href=""#a3"">Cookievarighed</a></p>
                            <p class=""cookie-menu""><a href=""#a4"">Efter samtykke</a></p>
                        </div>
                    </div>

                </div>
                <div class=""col-9"">
                    <div class=""content-section"">
                        <section id=""a1"">
                            <div class=""consent-headline-size-two consent-text-bold"">
                                Hvad er cookies.
                            </div>
                          ");
            WriteLiteral(@"  <p class=""consent-body-text"">
                                En cookie er en lille tekstfil som hentes ned til din PC, tablet eller
                                mobiltelefon. Det er din browser der henter cookier fra den hjemmeside som
                                du besøger. Denne cookie er specifik for den hjemmeside du besøger. Når du
                                så browser rundt på den samme hjemmeside sendes denne tekstfil med op til
                                hjemmesiden hver gang din browser kontakter hjemmesiden. Det er måden at en
                                hjemmeside har lidt hukommelse i forhold til dig som bruger.
                            </p>
                            <p class=""consent-body-text"">
                                Lovmæssigt deles cookier op i forskellige kategorier.
                            </p>

                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                Nødvendige");
            WriteLiteral(@"
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                Statistik
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                Personaliseret
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                Marketing
                            </p>

                            <p class=""consent-body-text consent-text-bold"">
                                Nødvendige cookies
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                indeholder information som en hjemmeside skal bruge for at kunne fungere.
                                Det er oftest data om handlinger foretaget af dig, f.eks.");
            WriteLiteral(@" en anmodning om
                                tjenester, som f.eks. indstilling af dine personlige præferencer,
                                indlogning eller udfyldning af en formular.
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                · Lovmæssigt behøver en hjemmeside IKKE at indhente accept fra dig som
                                bruger.
                            </p>

                            <p class=""consent-body-text consent-text-bold"">
                                Statistiske cookier
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                · bliver brugt til at optimere design, brugervenlighed og effektiviteten af
                                en hjemmeside. Fx ved at indsamle besøgsstatistik.
                            </p>

                            <p class=""consent-body");
            WriteLiteral(@"-text consent-indent-level-one"">
                                · Lovmæssigt SKAL en hjemmeside indhente accept fra dig som bruger.
                            </p>

                            <p class=""consent-body-text consent-text-bold"">
                                Personaliseret cookie
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                Indsamler information om hvordan du som bruger bevæger dig rundt på den
                                besøgte hjemmeside.
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                · Indsamler information om hvad du som bruger interesserer dig for. Den
                                indsamlede viden anvendes til at personalisere indholdet på hjemmesiden.
                            </p>
                            <p class=""consent-body-text consent-indent-level-o");
            WriteLiteral(@"ne"">
                                · Lovmæssigt SKAL en hjemmeside indhente accept fra dig som bruger.
                            </p>

                            <p class=""consent-body-text consent-text-bold"">
                                Marketing cookier
                            </p>
                            <p class=""consent-body-text consent-indent-level-one"">
                                indsamler information om hvordan du som bruger bevæger dig rundt på den
                                besøgte hjemmeside. Information anvendes til at målrette annoncer der
                                kunne interessere dig som bruger.
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                Indsamler information om hvad du som bruger søger efter på nettet. Med
                                denne information kan hjemmesiden målrette annoncer fra andre
                                leverandø");
            WriteLiteral(@"rer.
                            </p>

                            <p class=""consent-body-text consent-indent-level-one"">
                                · Lovmæssigt SKAL en hjemmeside indhente accept fra dig som bruger.
                            </p>

                            <p class=""consent-body-text"">
                                Se lovgrundlag her:
                                <a href=""https://www.retsinformation.dk/eli/lta/2011/1148"">
                                    Retsinformation
                                </a>
                            </p>

                        </section>
                        <section id=""a2"">
                            <div class=""consent-headline-size-two consent-text-bold"">
                                Nyxium cookies.
                            </div>
                            <p class=""consent-body-text "">
                                På nyxium’s hjemmeside anvender vi:
                            </p>
               ");
            WriteLiteral(@"             <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                Nødvendige cookies
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
                                .AspNetCore.Antiforgery.xxxxxxx hvor xxxxxxx er en tilfældige tegn
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Denne cookie indeholder en krypteret tekst som nyxium-programmet anvender
                                til at undgå at hackere kan manipulere med de data du indtaster.
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
                                nyxiumApp
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                         ");
            WriteLiteral(@"       Denne cookie indeholder krypteret information om din indlogning.
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
                                nyxium_consent
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Denne cookie anvendes til at huske hvilke cookies du har givet tilladelse
                                til
                            </p>
                            <p class=""consent-headline-size-two consent-text-bold"">
                                Marketing cookies (FaceBook)
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                fr og _fbp
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
      ");
            WriteLiteral(@"                          Annoncering, anbefalinger, indblik og måling
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger cookies til at vise annoncer for og lave forslag om virksomheder
                                og andre organisationer til personer, der kunne være interesserede i de
                                produkter, tjenester eller sager, der promoveres.
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Eksempel:
                                Cookies giver os mulighed for at levere annoncer til personer, der
                                tidligere har besøgt en virksomheds website, købt virksomhedens produkter
                                eller brugt dens apps, og for at anbefale produkter og tjenester ud fra
                                denne aktivitet. Cookies giver os");
            WriteLiteral(@" desuden mulighed for at begrænse det
                                antal gange, du får vist en annonce, så du ikke får vist den samme annonce
                                hele tiden. For eksempel bruges cookien 'fr' til at levere, måle og
                                forbedre relevansen af annoncer. Den har en levetid på 90 dage.
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger også cookies til at måle effektiviteten af annoncekampagner for
                                virksomheder, der bruger Facebook-produkterne.
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi bruger cookies til at tælle det antal gange, en annonce er blevet vist,
                                og til at beregne prisen for disse annoncer. Vi bruger også cookies til");
            WriteLiteral(@" at
                                måle, hvor ofte folk gør ting såsom at foretage et køb efter en
                                annonceeksponering. Cookien '_fbp' identificerer browsere med henblik på at
                                levere annoncer og siteanalyser. Den har en levetid på 90 dage.
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Cookies giver os mulighed for at levere og måle annoncer på tværs af
                                forskellige browsere og enheder, som bruges af den samme person.
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi kan bruge cookies til at forhindre, at du får vist den samme annonce
                                flere gange på de forskellige enheder, du bruger.
                            </p>
             ");
            WriteLiteral(@"               <p class=""consent-body-text consent-indent-level-two"">
                                Cookies giver os mulighed for at få indblik i de personer, der bruger
                                Facebook-produkterne, samt i de personer, der interagerer med annoncerne,
                                websites og apps fra vores annoncører og de virksomheder, der bruger
                                Facebook-produkterne.
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi bruger cookies til at hjælpe virksomheder med at få en forståelse af de
                                typer af personer, der synes godt om deres Facebook-side eller bruger deres
                                apps, så de kan levere mere relevant indhold og udvikle funktioner, der er
                                interessante for deres kunder.
                            </p>
");
            WriteLiteral(@"                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger desuden cookies, f.eks. vores cookie 'oo', der har en levetid på
                                fem år, så du kan vælge ikke at få vist annoncer fra Facebook baseret på
                                din aktivitet på tredjepartswebsites.
                                <a href=""https://www.facebook.com/help/769828729705201?ref=cookies"">
                                    Læs mere
                                </a>
                                om de oplysninger, vi modtager, hvordan vi beslutter, hvilke annoncer du
                                skal have vist på og uden for Facebook-produkterne, og de indstillinger, du
                                får stillet til rådighed.
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                presense
                 ");
            WriteLiteral(@"           </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
                                Funktioner og tjenester på sitet
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger cookies til at aktivere den funktionalitet, der hjælper os til at
                                levere Facebook-produkterne.
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi bruger cookies til at lagre indstillinger, til at registrere, hvornår du
                                har set eller interageret med indhold fra Facebook-produkter, og til at
                                give dig tilpasset indhold og tilpassede oplevelser. Vi bruger f.eks.
                                cookies til at give dig og andre forsl");
            WriteLiteral(@"ag og til at tilpasse indhold på
                                tredjepartswebsites, der integrerer vores sociale plugins. Hvis du er
                                administrator af en side, giver cookies dig mulighed for at skifte mellem
                                at slå indhold op fra din private Facebook-konto og fra den pågældende
                                side. Vi bruger cookies, f.eks. den sessionsbaserede cookie 'presense', til
                                at muliggøre din brug af chatvinduer i Messenger.
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger også cookies til at vise dig indhold, der er relevant for din
                                landeindstilling.
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi lagrer oplys");
            WriteLiteral(@"ninger i en cookie, der er placeret i din browser eller på
                                din enhed, så du får vist sitet på dit foretrukne sprog.
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                c_user og xs
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
                                Godkendelse
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger cookies til at verificere din konto og registrere, når du er
                                logget på, så vi kan gøre det nemmere for dig at få adgang til
                                Facebook-produkterne og give dig en relevant oplevelse og passende
                                funktioner.
                            </p>
              ");
            WriteLiteral(@"              <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi bruger cookies til at sørge for, at du bliver ved med at være logget på,
                                når du navigerer mellem Facebook-sider. Vi bruger også cookies til at huske
                                din browser, så du ikke behøver logge på Facebook flere gange, og så du
                                nemmere kan logge på Facebook via apps og websites fra tredjeparter. Vi
                                bruger f.eks. cookierne 'c_user' og 'xs' til dette formål. De har en
                                løbetid på 365 dage.
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                dpr og wd
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
          ");
            WriteLiteral(@"                      Effektivitet
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger cookies til at give dig den bedst mulige oplevelse.
                            </p>
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi bruger cookies til at dirigere trafik mellem servere og til at få
                                indblik i, hvor hurtigt Facebook-produkterne indlæses for forskellige
                                personer. Vi bruger desuden cookies til at registrere størrelsesforhold og
                                mål for din skærm og dine vinduer, og de hjælper os til at se, om du har
                                aktiveret højkontrasttilstand, så vi kan levere vores sites og apps
                                korrekt. Vi indsætter f.eks. cookierne 'dpr' og 'wd', som hv");
            WriteLiteral(@"er har en
                                levetid på 7 dage, for at levere en optimal oplevelse på din enheds skærm.
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                sb
                            </p>
                            <p class=""consent-body-text consent-indent-level-two consent-text-bold"">
                                Sikkerhed, site og produktintegritet
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                Vi bruger cookies til at beskytte din konto, dine data og
                                Facebook-produkterne.
                            </p>  
                            <p class=""consent-body-text consent-indent-level-three"">
                                Eksempel:
                                Vi kan bruge cookies til at identificere og indføre yderligere
  ");
            WriteLiteral(@"                              sikkerhedsforanstaltninger, hvis nogen forsøger at få adgang til en
                                Facebook-konto uden godkendelse, f.eks. ved hurtigt at gætte på forskellige
                                adgangskoder. Vi bruger også cookies til at lagre oplysninger, så vi kan
                                gendanne din konto i tilfælde af, at du har glemt din adgangskode, eller
                                kræve yderligere godkendelse i tilfælde af, at din konto er blevet hacket.
                                Dette omfatter f.eks. vores cookies 'sb' og 'dbln', som gør det muligt for
                                os at identificere din browser sikkert.
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                datr
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                       ");
            WriteLiteral(@"         FaceBook har ingen beskrivelse af denne cookie
                            </p>
                            <p class=""consent-body-text consent-indent-level-one consent-text-bold"">
                                spin
                            </p>
                            <p class=""consent-body-text consent-indent-level-two"">
                                FaceBook har ingen beskrivelse af denne cookie
                            </p>
                            <p>
                                Informationen om disse cookies er taget fra FaceBook’s hjemmeside:    <a href=""https://www.facebook.com/policies/cookies/"">(20+) Facebook</a>
                            </p>

                        </section>

                        <section id=""a3"">
                            <div class=""consent-headline"">
                                Cookievarighed.
                            </div>
                            
                        </section>
                        <");
            WriteLiteral(@"section id=""a4"">
                            <div class=""consent-headline"">
                                Efter samtykke.
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </article>
");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd58efe5939edd31f909c9ea642402a6df259c4d31488", async() => {
                WriteLiteral("\r\n        <input type=\"text\" name=\"cookieValue\" id=\"cookieValue\" hidden />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 411 "C:\Users\John\source\repos\WedigITCRM\WedigITCRM\Views\Shared\CookieConsent.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script>
    $(document).ready(function () {

        var Oldhref = window.location.href;

        var pos = Oldhref.indexOf('#');
        if (pos > -1) {
            Oldhref = Oldhref.substring(0, pos);
        }



        $('#consent').bind('click', function (event) {
            event.preventDefault();
            event.stopPropagation();

            var cookieText = {
                marketing: ""Accepted"",
                statistic: ""NotAccepted""
            };


            cvalue = ""statistic:"" + cookieText.statistic + ""marketing:"" + cookieText.marketing;
            exdays = 90;
            setCookie(""nyxium_consent"", cvalue, exdays);

            $('#cookieValue').val(cvalue);

            $(""#cookiesettings"").submit();

            //window.location.href = Oldhref;
        });

        $('#noconsent').bind('click', function (event) {
            event.preventDefault();
            event.stopPropagation();

            var cookieText = {
                mark");
            WriteLiteral(@"eting: ""NotAccepted"",
                statistic: ""NotAccepted""
            };

            cvalue = ""statistic:"" + cookieText.statistic + ""marketing:"" + cookieText.marketing;
            exdays = 90;
            setCookie(""nyxium_consent"", cvalue, exdays);

            window.location.href = Oldhref;
        });

    });


</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
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
