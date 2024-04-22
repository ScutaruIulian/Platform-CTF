using System.Web.Mvc;
using PlatformCTF.Atributes;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;

namespace Platform_CTF.Controllers
{
    [AdminMod]
    public class AdminController : Controller
    {
        private readonly ISession _sessionBL;

        public AdminController()
        {
            _sessionBL = new PlatformCTF.BusinessLogic.BusinessLogic().GetSessionBL();
        }

        // Action to view all users
        public ActionResult AllUsers()
        {
            var users = _sessionBL.GetAllUsers();
            return View(users);
        }

        // Action to view a specific user
        public ActionResult ViewUser(int id)
        {
            var user = _sessionBL.GetUserById(id);
            return View(user);
        }

        // Action to delete a user
        public ActionResult DeleteUser(int id)
        {
            _sessionBL.BanUser(id);
            return RedirectToAction("AllUsers");
        }

        // Action to view all sessions
        public ActionResult AllSessions()
        {
            var sessions = _sessionBL.GetAllSessions();
            return View(sessions);
        }

        // Action to delete a session
        public ActionResult DeleteSession(int id)
        {
            _sessionBL.DeleteSession(id);
            return RedirectToAction("AllSessions");
        }
    }
}