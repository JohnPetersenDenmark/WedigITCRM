using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    public class ImpersonationController : Controller
    {

        // https://tech.trailmax.info/2017/07/user-impersonation-in-asp-net-core/


        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public ImpersonationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }

       
        public async Task<IActionResult> ImpersonateUser(String userId)
        {
            
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var impersonatedUser = await _userManager.FindByIdAsync(userId);

            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(impersonatedUser);

            userPrincipal.Identities.First().AddClaim(new Claim("OriginalUserId", currentUserId));
            userPrincipal.Identities.First().AddClaim(new Claim("IsImpersonating", "true"));

            // sign out the current user
            await _signInManager.SignOutAsync();



            // await HttpContext.SignInAsync(cookieOptions.ApplicationCookieAuthenticationScheme, userPrincipal);
           await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, userPrincipal);
            return RedirectToAction("Index", "Home");
        }
        


        public async Task<IActionResult> StopImpersonation()
        {

            var claims = User.Claims;
            if (!User.HasClaim("IsImpersonating", "true"))
            {
                throw new Exception("You are not impersonating now. Can't stop impersonation");
            }

            var originalUserId = User.FindFirst("OriginalUserId").Value;

            var originalUser = await _userManager.FindByIdAsync(originalUserId);

            await _signInManager.SignOutAsync();

            await _signInManager.SignInAsync(originalUser, isPersistent: true);

            return RedirectToAction("Index", "Home");
        }
    }
}
