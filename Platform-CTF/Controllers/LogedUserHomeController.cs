using System.Web.Mvc;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;

namespace Platform_CTF.Controllers
{
    public class LoggedUserHomeController : Controller
    {
        private readonly ISession _session = new BusinessLogic().GetSessionBL();

        public ActionResult LoggedHome()
        {
            var user = _session.GetUserByCookie(Request.Cookies["X-KEY"]?.Value);
            if (user != null) ViewBag.UserRole = user.Level;
            return View();
        }
    }
}