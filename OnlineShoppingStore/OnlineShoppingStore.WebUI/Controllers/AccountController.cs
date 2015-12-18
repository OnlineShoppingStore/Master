using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.WebUI.Models;
using OnlineShoppingStore.Domain.Abstract;
using System.Web.Security;

namespace OnlineShoppingStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IAuthentication authentication;
        public AccountController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model,string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                  if(authentication.Authenticate(model.UserName,model.Password) )
                  {
                      FormsAuthentication.SetAuthCookie(model.UserName, false);
                      return Redirect(ReturnUrl ?? Url.Action("Index", "Admin"));
                  }
                  else
                  {
                      ModelState.AddModelError("","Incorrect username or password");
                      return View();
                  }

            }
            else
            {
                return View();
            }
           // return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }
	}
}