using System.Collections.Generic;
using System.Web.Mvc;
using PlatformCTF.BusinessLogic;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace Platform_CTF.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly ISession _session;

        public ChallengeController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
        }

        [HttpPost]
        public JsonResult SubmitFlag(int challengeId, string submittedFlag)
        {
            var response = _session.SubmitFlag(challengeId, submittedFlag);
            return Json(response);
        }


        [HttpGet]
        public ActionResult Challenges()
        {
            var exercisesResponse = _session.ShowAllExercises();
            List<Exercise> exercises;

            if (exercisesResponse != null && exercisesResponse.Exercises != null)
            {
                exercises = new List<Exercise>(exercisesResponse.Exercises);
            }
            else
            {
                exercises = new List<Exercise>();
            }

            return View("Challenges", exercises);
        }
    }
}