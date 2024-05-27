using System;
using System.Security.Authentication;
using System.Web.Mvc;
using AutoMapper;
using Platform_CTF.Models;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace Platform_CTF.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session = new BusinessLogic().GetSessionBL();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegister, URegisterData>());
                var mapper = config.CreateMapper();
                var data = mapper.Map<URegisterData>(register);

                data.IpAddress = Request.UserHostAddress;
                data.RegisterDateTime = DateTime.Now;

                var userRegister = _session.UserRegister(data);

                if (userRegister == null) throw new AuthenticationException("No response auth");

                if (userRegister.Status)
                {
                    var cookie = _session.GenCookie(register.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("LoggedHome", "LoggedUserHome");
                }
            }

            ModelState.AddModelError("", "Modelstate invalid");
            return RedirectToAction("Landing", "Home");
        }
    }
}