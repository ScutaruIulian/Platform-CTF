﻿using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PlatformCTF.Domains.Entities.User;
using Platform_CTF.Models;
using PlatformCTF.BusinessLogic.Interfaces;

namespace PlatformCTF.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View($"~/Views/Home/Login.cshtml");
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
                    HttpCookie cookie = _session.GenCookie(login.Credentials);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View($"~/Views/Home/index.cshtml");
                }
            }

            return View($"~/Views/Home/LogedHome.cshtml");
        }

        public ActionResult Login()
        {
            throw new NotImplementedException();
        }
    }
}