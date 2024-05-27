using System.Linq;
using System.Web.Mvc;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.DBModel.Seed;
using PlatformCTF.BusinessLogic.Interfaces;

namespace Platform_CTF.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly ExerciseContext _exercises = new();
        private readonly ISession _session = new BusinessLogic().GetSessionBL();

        [HttpPost]
        public JsonResult SubmitFlag(int challengeId, string submittedFlag)
        {
            var response = _session.SubmitFlag(challengeId, submittedFlag);
            return Json(response);
        }


        [HttpGet]
        public ActionResult Challenges()
        {
            var display = _exercises.Exercises.ToList();

            return View(display);
        }
    }
}