using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Platform_CTF.Models;
using PlatformCTF.Atributes;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.DBModel.Seed;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace Platform_CTF.Controllers
{
    [AdminMod]
    public class AdminController : Controller
    {
        private readonly ISessionAdmin _sessionAdmin;

        public AdminController()
        {
            var bl = new BusinessLogic();
            _sessionAdmin = bl.GetSessionAdminBL();
        }

        public ActionResult Index()
        {
            var adminResp = _sessionAdmin.GetAllLoggedUsers();
            var users = adminResp.Users; // Assuming Users is a property of type IEnumerable<UserMinimal>
            var exerciseAdd = new ExerciseAdd();

            var model = new Tuple<List<UDBTable>, ExerciseAdd>(users, exerciseAdd);

            return View("~/Views/Home/AdminPanel.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExercise(Exercise exercise)
        {
            var resp = _sessionAdmin.AddExercise(exercise);
            if (resp.Status)
            {
                // Create a new Challenge
                var challenge = new Exercise
                {
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Category = exercise.Category,
                    Flag = exercise.Flag
                };

                // Add the Challenge to the database
                using (var db = new ExerciseContext())
                {
                    db.Exercises.Add(challenge);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", resp.StatusMsg);
                return View($"~/Views/Home/AdminPanel.cshtml");
            }
        }

        public ActionResult BanUser(int id)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    var banDuration = TimeSpan.FromDays(7); // Set the ban duration as needed
                    var resp = _sessionAdmin.BanUser(user.Username, banDuration);
                    if (resp.Status)
                    {
                        user.IsBanned = false; // Set IsBanned to false
                        db.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", resp.StatusMsg);
                        return View($"~/Views/Home/AdminPanel.cshtml");
                    }
                }
                else
                {
                    return new HttpNotFoundResult("User not found");
                }
            }
        }

        public ActionResult LogOut()
        {
            var cookie = Request.Cookies["X-KEY"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            return View($"~/Views/Home/Login.cshtml");
        }
    }
}