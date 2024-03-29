﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WedigITCRM.Maintenance;
using WedigITCRM.Models;
using WedigITCRM.ActionFilters;
using WedigITCRM.Utilities;
using WedigITCRM.DineroAPI;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.SQLImplmementationModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace WedigITCRM
{
    public class Startup
    {

     

        private IConfiguration _config;
        private ILogger<Startup> _logger;
        

        public Startup(IConfiguration config, ILogger<Startup> logger)
        {
            _config = config;
            _logger = logger;          
        }
 
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                _logger.LogError("start of ConfigureServices");

                //services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString ("WedigitDbConnection")));
                services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
                services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                })
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders()
                    .AddErrorDescriber<LocalizedIdentityErrorDescriber>();

            


                services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
                services.AddMvc();
                services.AddScoped<ICompanyRepository, SQLCompanyRepository>();
                services.AddScoped<ICompanyAccountRepository, SQLCompanyAccountRepository>();
                services.AddScoped<IRelateCompanyAccountWithUserRepository, SQLRelateCompanyAccountWithUserRepository>();
                services.AddScoped<IRelateCompanyAccountWithRoleRepository, SQLRelateCompanyAccountWithRoleRepository>();
                services.AddScoped<IPostalCodeRepository, SQLPostalCodeRepository>();
                services.AddScoped<IContactPersonRepository, SQLContactPersonRepository>();
                services.AddScoped<IActivityRepository, SQLActivityRepository>();

                services.AddScoped<IVendorRepository, SQLVendorRepository>();
                services.AddScoped<INoteRepository, SQLNoteRepository>();
                services.AddScoped<IContentTypeRepository, SQLContentTypeRepository>();
                services.AddScoped<IStockItemRepository, SQLStockItemRepository>();
                services.AddScoped<IStockItemCategory1Repository, SQLStockItemCategory1Repository>();
                services.AddScoped<IStockItemCategory2Repository, SQLStockItemCategory2Repository>();
                services.AddScoped<IStockItemCategory3Repository, SQLStockItemCategory3Repository>();
                services.AddScoped<IJobServiceTypeRepository, SQLJobserviceTypeRepository>();
                services.AddScoped<IBookingResourceRepository, SQLBookingResourceRepository>();
                services.AddScoped<ICalendarEventRepository, SQLCalendarEventRepository>();
                services.AddScoped<IBookingServiceRepository, SQLBookingServiceRepository>();
                services.AddScoped<IBookingSetupRepository, SQLBookingSetupRepository>();
                services.AddScoped<ILicenseType, SQLLicenseTypeRepository>();
                services.AddScoped<ICountryRepository, SQLCountryRepository>();
                services.AddScoped<IAttachmentRepository, SQLAttachmentRepository>();               
                services.AddScoped<DineroAPIConnect>();


                services.AddScoped<EmailUtility>();

              
                services.AddMvc(options =>
                {
                    options.Filters.Add<GetCompanyAccountFilter>();
                    options.EnableEndpointRouting = false;
                });

                services.AddAuthentication().AddGoogle(options =>
                {
                // https://console.developers.google.com/apis/dashboard?project=api-project-305705860120
                options.ClientId = "305705860120-nopt8838891tv00skpj95o572gkv8r63.apps.googleusercontent.com";
                    options.ClientSecret = "sBjpboSHK85r5qYcA5yzHQH4";
                });

                services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = "8879b4b8-6b07-45de-bdd8-fbf37a3e57cc";
                    microsoftOptions.ClientSecret = "OYN5XB70y:rPh4eqaUl.kbXTFQYDjH==";
                });

                services.AddAuthentication().AddFacebook(facebookOptions =>
                {
                    facebookOptions.ClientId = "2473848212902883";
                    facebookOptions.ClientSecret = "9e2c4644e71a19cbdaf1ebb493c19c17";
                });

                services.AddAuthentication().AddTwitter(twitterOptions =>
                {
                    twitterOptions.ConsumerKey = "8VM3rqTnDKcUccG7R1qEsixuJ";
                    twitterOptions.ConsumerSecret = "GA3UtyptNkvJcdd5jd4VMVmB5w2GdXt6mIgLQ64dTbXqIFieBt";
                    twitterOptions.RetrieveUserDetails = true;
                });

                _logger.LogError("end of ConfigureServices");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                _logger.LogError("start of Configure method");

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                   

                    app.UseGlobalExceptionHandler(env
                                   , _logger
                                   , errorPagePath: "/Home/Error"
                                   , respondWithJsonErrorDetails: true);
                                 

                    // app.UseHsts(); dette skal prøves af.
                }

                // app.UseHttpsRedirection();    dette skal prøves af.

                app.UseStaticFiles();
                app.UseAuthentication();
                app.UseMvcWithDefaultRoute();
                _logger.LogError("end of Configure method");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
