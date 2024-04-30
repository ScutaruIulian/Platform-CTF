/*using System.Web.Mvc;
using Platform_CTF.Models;

namespace Platform_CTF.Controllers
{
    public class ChallengeController : Controller
    {
        // GET: Challenge
        public ActionResult Index()
        {
            // TODO: Get challenges from database and pass to view
            return View();
        }

        // POST: Challenge/Add
        [HttpPost]
        public ActionResult Add(Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                //TODO: Add challenge to database
                return RedirectToAction("Index");
            }

            return View(challenge);
        }
    }
}*/