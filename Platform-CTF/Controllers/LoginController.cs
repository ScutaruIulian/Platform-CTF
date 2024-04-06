using System;
using System.Web.Mvc;
using PlatformCTF.BusinessLogic.Interfaces;
using Platform_CTF.Models;
using PlatformCTF.Domains.Entities.User;
using System.Web.UI.WebControls;

namespace Platform_CTF.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new PlatformCTF.BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // Aquire login
        public ActionResult Index()
        {
            //return View();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credentials = login.Credentials,
                    Password = login.Password,
                    LoginDateTime = DateTime.Now,
                    LoginIp = Request.UserHostAddress
                };

                var userLogin = _session.UserLogin(data);
                if (userLogin)
                {
                    //ADD COOKIE
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }

            //return View();
            return View();
        }
    }
}