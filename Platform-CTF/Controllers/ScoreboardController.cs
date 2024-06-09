using System.Web.Mvc;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;

namespace Platform_CTF.Controllers
{
    public class ScoreboardController : Controller
    {
        private readonly ISession _session = new BusinessLogic().GetSessionBL();

        public ActionResult Scoreboard()
        {
            var score = _session.GetScoreBoardStatus();
            return View(score);
        }
    }
}