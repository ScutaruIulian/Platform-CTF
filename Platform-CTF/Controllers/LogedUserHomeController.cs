using System.Web.Mvc;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;

namespace Platform_CTF.Controllers
{
    public class LogedUserHomeController: Controller
    {
        private readonly ISession _session;

        public LogedUserHomeController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult Index()
        {
            var user = _session.GetUserByCookie(Request.Cookies["X-KEY"].Value);
            ViewBag.UserRole = user.Level;
            return View($"~/Views/Home/LogedHome.cshtml");
        }
    }
}