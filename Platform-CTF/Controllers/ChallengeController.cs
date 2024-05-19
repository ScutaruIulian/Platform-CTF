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


        /*// POST: Challenge/SubmitFlag
        [HttpPost]
        public ActionResult SubmitFlag(int challengeId, string submittedFlag)
        {
            var challenge = _context.Exercises.Find(challengeId);
            if (challenge == null)
            {
                return new HttpNotFoundResult("Challenge not found");
            }

            if (challenge.Flag == submittedFlag)
            {
                // The submitted flag is correct
                // You can add any additional logic here, such as awarding points to the user
                return Content("Correct flag!");
            }
            else
            {
                // The submitted flag is incorrect
                return Content("Incorrect flag.");
            }
        }*/
        [HttpGet]
        public ActionResult Challenges()
        {
            var exercisesResponse = _session.ShowAllExercises(); 
            var exercises = exercisesResponse.Exercises; 
            if (exercises == null) 
            {
                exercises = new List<Exercise>(); 
            }
            var model = new List<Exercise>(exercises); 

            return View("Challenges",model);
        }
    }
}