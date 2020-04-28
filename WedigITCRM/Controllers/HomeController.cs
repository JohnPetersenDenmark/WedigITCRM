using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WedigITCRM.VirkAPI;

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private IPostalCodeRepository _postalCodeRepository;
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPostalCodeRepository postalCodeRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {

            _signInManager = signInManager;
            _userManager = userManager;
            _postalCodeRepository = postalCodeRepository;
            _logger = logger;
        }


        [AllowAnonymous]
        public IActionResult Index(CompanyAccount companyAccount)
        {
            _logger.LogError("Entering index action in home controller");

            if (!_signInManager.IsSignedIn(User))
            {
                _logger.LogError("index action in home controller redirecting to frontpage controller index action");
                return RedirectToAction("index", "FrontPage");
            }

            if (companyAccount.SubscriptionCRM)
            {
                _logger.LogError("index action in home controller redirecting to Customer controller AllCustomers action");
                return RedirectToAction("AllCustomers", "Customer");
            }

            if (companyAccount.SubscriptionVendor)
            {
                return RedirectToAction("AllVendors", "Vendor");
            }

            return RedirectToAction("index", "FrontPage");
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getCity(string zipCodeId)
        {
            if (String.IsNullOrEmpty(zipCodeId))
            {
                return new JsonResult("No zip code id");
            }

            PostalCode zipCode = _postalCodeRepository.getPostalCodeById(int.Parse(zipCodeId));
            if (zipCode == null)
            {
                return new JsonResult("Invalid ip code id");
            }


            return new JsonResult(zipCode.City);
        }

        [Produces("application/json")]

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> searchInVirkByCompanyName(string term)
        {

            VirkAPI.Companies virkapi = new VirkAPI.Companies();
            VirkQuery virkquery = new VirkQuery();

            virkquery.query.query_string.query = term;

            VirkResponse virkResponse = await virkapi.search(virkquery);

            List<CompanyData> companies = new List<CompanyData>();


            List<vedIkke> result = virkResponse.hits.hits_property;

            foreach (var x in result)
            {
                CompanyData companyData = new CompanyData();

                companyData.label = x._source.Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn;
                // companyData.value = x._source.Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn;
                companyData.cvrNumber = x._source.Vrvirksomhed.cvrNummer.ToString();


                companyData.street = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.vejnavn;
                companyData.houseNumber = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerFra.ToString();
                companyData.zip = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer.ToString();
                companyData.zipId = getZipIdFromZipNumber(x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer).ToString();
                companyData.city = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postdistrikt;
                if (x._source.Vrvirksomhed.telefonNummer.Count > 0)
                {
                    List<string> telefonNummerList = new List<string>();
                    foreach ( var CVRtelefonNummer in x._source.Vrvirksomhed.telefonNummer)
                    {
                        if (! string.IsNullOrEmpty(CVRtelefonNummer.noName.kontaktoplysning))
                        {
                            telefonNummerList.Add(CVRtelefonNummer.noName.kontaktoplysning);
                        }
                    }
                 
                       companyData.phoneNumber = string.Join(",", telefonNummerList);
                }
                else
                {
                    companyData.phoneNumber = null;
                }
               
                if (x._source.Vrvirksomhed.hjemmeside.Count > 0)
                {
                    List<string> homePageList = new List<string>();
                    foreach (var CVRhomePage in x._source.Vrvirksomhed.hjemmeside)
                    {
                        if (!string.IsNullOrEmpty(CVRhomePage.noName1.kontaktoplysning))
                        {
                            homePageList.Add(CVRhomePage.noName1.kontaktoplysning);
                        }
                    }
                    companyData.homePage = string.Join(",", homePageList);
                }
                else
                {
                    companyData.homePage = null;
                }
               

                companies.Add(companyData);
            }


            return new JsonResult(companies);
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> searchInVirkByCVR(string term)
        {

            VirkAPI.Companies virkapi = new VirkAPI.Companies();
            VirkQuery virkquery = new VirkQuery();

            virkquery.query.query_string.default_field = "Vrvirksomhed.cvrNummer";

            int num;
            bool termIsNumeric = Int32.TryParse(term, out num);

            if (termIsNumeric)
            {

                if (term.Length < 8)
                {
                    term = term + "*";
                }
            }
            else
            {
                term = "88888888";
            }

            virkquery.query.query_string.query = term;

            VirkResponse virkResponse = await virkapi.search(virkquery);

            List<CompanyData> companies = new List<CompanyData>();


            List<vedIkke> result = virkResponse.hits.hits_property;

            foreach (var x in result)
            {
                CompanyData companyData = new CompanyData();

                companyData.label = x._source.Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn;
                companyData.cvrNumber = x._source.Vrvirksomhed.cvrNummer.ToString();


                companyData.street = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.vejnavn;
                companyData.houseNumber = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerFra.ToString();
                companyData.zip = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer.ToString();
                companyData.zipId = getZipIdFromZipNumber(x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer).ToString();
                companyData.city = x._source.Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postdistrikt;
                companyData.phoneNumber = string.Join(",", x._source.Vrvirksomhed.telefonNummer);
                companyData.homePage = string.Join(",", x._source.Vrvirksomhed.hjemmeside);

                companies.Add(companyData);
            }


            return new JsonResult(companies);
        }

        [AllowAnonymous]
        public int getZipIdFromZipNumber(int zip)
        {
            int zipCode = 0;
            //PostalCode postalCode = _postalCodeRepository.getPostalCodeById(Int32.Parse(model.selectedZipId));
            var zips = _postalCodeRepository.getAllZips().Where(x => x.Zip.Equals(zip.ToString())).ToList();

            if (zips.Count == 1)
            {
                PostalCode postalCode = zips.First();
                zipCode = postalCode.Id;
            }

            return zipCode;
        }






    }
}