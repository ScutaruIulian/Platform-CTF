using System;
using System.Web.Mvc;
using AutoMapper;
using Platform_CTF.Models;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domain.Entities.User;
using PlatformCTF.Domains.Entities.User;

namespace Platform_CTF.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session = new BusinessLogic().GetSessionBL();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserLogin, ULoginData>());
                var mapper = config.CreateMapper();
                var data = mapper.Map<ULoginData>(login);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    var cookie = _session.GenCookie(login.Credentials);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("LoggedHome", "LoggedUserHome");
                }

                ModelState.AddModelError("", userLogin.StatusMsg);
                return View("~/Views/Home/Login.cshtml");
            }

            return View("~/Views/Home/LogedHome.cshtml");
        }

        public UserMinimal GetUserDetails(string authToken)
        {
            return _session.GetUserByCookie(authToken);
        }

        public ActionResult LogOut()
        {
            var cookie = Request.Cookies["X-KEY"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                Session.Abandon();
            }

            return View("Login", "Login");
        }
    }
}