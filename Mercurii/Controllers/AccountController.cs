using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Mercurii.Models;
using Model.DTO;
using BAL.Interface;

namespace Mercurii.Controllers
{
    public class AccountController : Controller
    {
        private IUserManager UserManager;

        public AccountController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult SignUp()
        {
            return View(new UserDTO());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserDTO user)
        {
            if (user.Password == null)
            {
                ModelState.AddModelError("Password", "Input password, please");
            }
            if (UserManager.EmailIsExist(user.Email))
            {
                ModelState.AddModelError("Email", "This email currently exists");
            }
            if (!ModelState.IsValid)
                return View(user);

            UserManager.Insert(user);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = UserManager.GetByEmail(model.Name, model.Password) ?? UserManager.GetByUserName(model.Name, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("Name", "Uncorrect email or password");
                    ModelState.AddModelError("Password", "Uncorrect email or password");
                }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName, ClaimValueTypes.String));
                    claim.AddClaim(
                        new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                            "OWIN Provider", ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleName, ClaimValueTypes.String));

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}