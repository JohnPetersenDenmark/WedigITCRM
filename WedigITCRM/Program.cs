using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using WedigITCRM.Maintenance;
using WedigITCRM.Models;

namespace WedigITCRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
               .ConfigureLogging((hostingContext, logging) =>
               {
                   logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                   logging.AddConsole();
                   logging.AddDebug();
                   logging.AddEventSourceLogger();
                   // Enable NLog as one of the Logging Provider
                   logging.AddNLog();
               })

              .ConfigureServices(services =>
              {
                  // START added this code 26-05-2020
                  var serviceProvider = services.BuildServiceProvider();
                  var scope = serviceProvider.CreateScope();
                  var scopedServices = scope.ServiceProvider;
                  var db = scopedServices.GetRequiredService<IConfiguration>();

                  services.AddDbContextPool<AppDbContext>(options =>
                  {
                      options.UseSqlServer(db.GetConnectionString("DefaultConnection"));
                  });

                  services.AddScoped<IRelateCompanyAccountWithUserRepository, SQLRelateCompanyAccountWithUserRepository>();

                  // END added this code 26-05-2020

                  services.AddHostedService<SynchronizeDineroContactsService>();
                  services.AddHostedService<SynchronizeDineroStockItems>();
                  services.AddHostedService<SendActivitiesNotificationsservice>();
                  services.AddHostedService<SetSuperAdministrator>();
              })

            .UseStartup<Startup>();






    }
}
