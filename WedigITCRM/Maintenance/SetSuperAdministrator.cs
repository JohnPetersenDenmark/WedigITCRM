using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WedigITCRM.Maintenance
{

    public class SetSuperAdministrator : IHostedService
    {

        private Timer _timer;
        private readonly IServiceScopeFactory scopeFactory;
        private ILogger<SetSuperAdministrator> _logger;

        public SetSuperAdministrator(IServiceScopeFactory scopeFactory, ILogger<SetSuperAdministrator> logger)
        {
            this.scopeFactory = scopeFactory;
            this._logger = logger;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CreateSuperAdministrator, null, 0, 60000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void CreateSuperAdministrator(object state)
        {
            var scope = scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var relateUserWithCompanyAccountRepository = scope.ServiceProvider.GetRequiredService<IRelateCompanyAccountWithUserRepository>();
            var companyAccountRepository = scope.ServiceProvider.GetRequiredService<ICompanyAccountRepository>();
            var licenseTypeRepository = scope.ServiceProvider.GetRequiredService<ILicenseType>();


            IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
            if (adminRole == null)
            {
                IdentityRole newAdminRole = new IdentityRole();
                newAdminRole.Name = "Admin";

                // Saves the role in the underlying AspNetRoles table
                IdentityResult newIdentityResult = roleManager.CreateAsync(newAdminRole).Result;
            }

            IdentityRole sysAdminRole = roleManager.FindByNameAsync("SystemAdministrator").Result;
            if (sysAdminRole == null)
            {
                IdentityRole newSysAdminRole = new IdentityRole();
                newSysAdminRole.Name = "SystemAdministrator";

                // Saves the role in the underlying AspNetRoles table
                IdentityResult newIdentityResult = roleManager.CreateAsync(newSysAdminRole).Result;
            }


            IdentityUser systemAdministratorUser = userManager.FindByNameAsync("nyxiumAdmin@wedigit.dk").Result;

            if (systemAdministratorUser == null)
            {
                systemAdministratorUser = new IdentityUser { UserName = "nyxiumAdmin@wedigit.dk", Email = "nyxiumAdmin@wedigit.dk" };
                var result = userManager.CreateAsync(systemAdministratorUser, "Keiler1234!").Result;
                if (result.Succeeded)
                {
                    IdentityRole role = roleManager.FindByNameAsync("SystemAdministrator").Result;

                    if (role != null)
                    {
                        var result1 = userManager.AddToRoleAsync(systemAdministratorUser, role.Name).Result;
                    }

                    LicenseType licenseType = null;
                    List<LicenseType> licenseTypes = licenseTypeRepository.GetAllLicenseTypes().Where(tmplicenseType => tmplicenseType.Name.Equals("Free")).ToList();
                    if (licenseTypes.Count == 1)
                    {
                        licenseType = licenseTypes.First();
                    }

                    var relations = relateUserWithCompanyAccountRepository.GetAllRelateCompanyAccountWithUser().Where(relation => relation.user.Equals(systemAdministratorUser.Id)).ToList();
                    if (relations.Count == 1)
                    {
                        RelateCompanyAccountWithUser relateCompanyAccountWithUser = relations.First();



                        CompanyAccount companyAccount = companyAccountRepository.GetCompanyAccount(relateCompanyAccountWithUser.companyAccount);
                        if (companyAccount == null)
                        {
                            companyAccount = new CompanyAccount();
                            companyAccount.registrationDate = DateTime.Now;
                            companyAccount.activationKey = Guid.NewGuid();
                            if (licenseType != null)
                            {
                                companyAccount.NyxiumLicenseTypeName = licenseType.Name;
                                companyAccount.NyxiumLicenseTypeId = licenseType.Id;
                            }

                            companyAccount.CompanyName = "nyxium.dk";
                            CompanyAccount TheNewCompanyAccount = companyAccountRepository.Add(companyAccount);

                            relateCompanyAccountWithUser.companyAccount = TheNewCompanyAccount.companyAccountId;
                            relateUserWithCompanyAccountRepository.Update(relateCompanyAccountWithUser);
                        }
                    }
                    else
                    {
                        CompanyAccount companyAccount = new CompanyAccount();
                        companyAccount.registrationDate = DateTime.Now;
                        companyAccount.activationKey = Guid.NewGuid();
                        if (licenseType != null)
                        {
                            companyAccount.NyxiumLicenseTypeName = licenseType.Name;
                            companyAccount.NyxiumLicenseTypeId = licenseType.Id;
                        }
                        companyAccount.CompanyName = "wedigIT ApS";
                        CompanyAccount TheNewCompanyAccount = companyAccountRepository.Add(companyAccount);

                        RelateCompanyAccountWithUser relateCompanyAccountWithUser = new RelateCompanyAccountWithUser();
                        relateCompanyAccountWithUser.companyAccount = TheNewCompanyAccount.companyAccountId;
                        relateCompanyAccountWithUser.user = systemAdministratorUser.Id;
                        relateCompanyAccountWithUser.userName = systemAdministratorUser.UserName;
                        relateCompanyAccountWithUser.CompanyName = companyAccount.CompanyName;

                        relateUserWithCompanyAccountRepository.Add(relateCompanyAccountWithUser);
                    }
                }
            }
        }
    }
}
