using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Platform_CTF.Attributes;
using Platform_CTF.Models;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace Platform_CTF.Controllers
{
    [AdminMod]
    public class AdminController : Controller
    {
        private readonly ISessionAdmin _sessionAdmin = new BusinessLogic().GetSessionAdminBL();

        public ActionResult AdminPanel()
        {
            var adminResp = _sessionAdmin.GetAllRegisteredUsers();
            var users = adminResp.Users;
            var addExercise = new Exercise();
            var model = new Tuple<List<UDBTable>, Exercise>(users, addExercise);

            return View(model);
        }

        // public ActionResult BanUser(int id)
        // {
        //     using (var db = new UserContext())
        //     {
        //         var user = db.Users.FirstOrDefault(u => u.Id == id);
        //         if (user != null)
        //         {
        //             var banDuration = TimeSpan.FromDays(1); // Set the ban duration as needed
        //             var resp = _sessionAdmin.BanUser(user.Username, banDuration);
        //             if (resp.Status)
        //             {
        //                 user.IsBanned = false; // Set IsBanned to false
        //                 db.SaveChanges();
        //                 return RedirectToAction("AdminPanel", "Admin");
        //             }
        //             else
        //             {
        //                 ModelState.AddModelError("", resp.StatusMsg);
        //                 return RedirectToAction("AdminPanel", "Admin");
        //             }
        //         }
        //         else
        //         {
        //             return new HttpNotFoundResult("User not found");
        //         }
        //     }
        // }

        public ActionResult LogOut()
        {
            var cookie = Request.Cookies["X-KEY"];
            if (cookie == null) return RedirectToAction("Landing", "Home");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);

            return RedirectToAction("Landing", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void AddExercise(AddExercise exercise)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AddExercise, Exercise>());
                var mapper = config.CreateMapper();
                var data = mapper.Map<Exercise>(exercise);

                var addExercise = _sessionAdmin.AddExercise(data);
                if (addExercise == null)
                {
                    ModelState.AddModelError("", "No db response");
                    return;
                }

                if (addExercise.Status)
                {
                }
                else
                {
                    ModelState.AddModelError("", addExercise.StatusMsg);
                }
            }
        }
    }
}