using System.Web.Mvc;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace Platform_CTF.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new PlatformCTF.BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // Aquire registration
        public ActionResult Index()
        { 
            return View($"~/Views/Home/Register.cshtml");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(URegisterData register)
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    //return View($"~");
                }
            }

            return View($"~/Views/Home/Register.cshtml");
        }
    }
}