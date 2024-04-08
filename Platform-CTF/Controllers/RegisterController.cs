using System.Web.Mvc;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // Aquire registration
        public ActionResult Index()
        {
            //return View();
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(URegisterData register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Username = register.Username,
                    Password = register.Password,
                    Email = register.Email
                };

                var userRegister = _session.UserRegister(data);
                if (userRegister != null && userRegister.Status)
                {
                    //ADD COOKIE
                    return RedirectToAction("Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    //return View();
                }
            }

            //return View();
            return null;
        }
    }
}