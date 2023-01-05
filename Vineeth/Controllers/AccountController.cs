using Microsoft.AspNetCore.Mvc;
using Vineeth.Models;
using Vineeth.Repository;

namespace Vineeth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accrep;

        public AccountController(IAccountRepository Accrep)
        {
            _accrep = Accrep;
        }
        [Route("SignUP")]
        public IActionResult SignUP()
        {
            return View();
        }
        [Route("SignUP")]
        [HttpPost]
        public async Task<IActionResult> SignUP(SignupUserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accrep.createuser(user);

                ModelState.Clear();
                if (!result.Succeeded)
                {
                    foreach (var errormessage in result.Errors)
                    {
                        ModelState.AddModelError("", errormessage.Description);
                        return View(user);
                    }
                }

            }
            return View();
        }
        [Route("Sigin")]
        public async Task<IActionResult> Sigin()
        {

            return View();
        }
        [Route("Sigin")]
        [HttpPost]
        public async Task<IActionResult> Sigin(SignINModel user, string returnurl)
        {
            if (ModelState.IsValid)
            {
                var Results = await _accrep.passwordsignAsync(user);
                if (Results.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnurl))
                    {
                        return LocalRedirect(returnurl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid credentials");
            }
            return View(user);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accrep.signout();
            return RedirectToAction("Index", "Home");
        }
        [Route("Change_password")]
        public async Task<IActionResult> Change_password()
        {
            await _accrep.signout();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost("Change_password")]
        public async Task<IActionResult> Change_password(Changepasswordmodel model)
        {
           if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}
