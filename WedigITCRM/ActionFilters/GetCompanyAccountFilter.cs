using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.Maintenance;
using WedigITCRM.Models;

namespace WedigITCRM.ActionFilters
{
    public class GetCompanyAccountFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var svc = context.HttpContext.RequestServices;


            SignInManager<IdentityUser> signInManager = (SignInManager<IdentityUser>)svc.GetService(typeof(SignInManager<IdentityUser>));
            UserManager<IdentityUser> userManager = (UserManager<IdentityUser>)svc.GetService(typeof(UserManager<IdentityUser>));
            ICompanyAccountRepository companyAccountRepository = (ICompanyAccountRepository)svc.GetService(typeof(ICompanyAccountRepository));
            IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository = (IRelateCompanyAccountWithUserRepository)svc.GetService(typeof(IRelateCompanyAccountWithUserRepository));

            
            if (signInManager.IsSignedIn(context.HttpContext.User))
            {
                string userId = userManager.GetUserId(context.HttpContext.User);
                if (! String.IsNullOrEmpty(userId) )
                {
                    List<RelateCompanyAccountWithUser> relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(x => x.user.Equals(userId)).ToList();
                    if (relateCompanyAccountWithUsers.Count == 1)
                    {
                        RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                        CompanyAccount CompanyAccount = companyAccountRepository.GetCompanyAccount(RelateCompanyAccountWithUser.companyAccount);
                        context.ActionArguments["CompanyAccount"] = CompanyAccount;
                    }
                }
            }


    



            base.OnActionExecuting(context); // 
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        //

    }
}
