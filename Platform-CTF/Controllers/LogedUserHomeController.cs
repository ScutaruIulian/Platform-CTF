using System.Web.Mvc;

namespace Platform_CTF.Controllers
{
    public class LogedUserHomeController: Controller
    {
        public ActionResult Index()
        {
            return View($"~/Views/Home/LogedHome.cshtml");
        }
    }
}