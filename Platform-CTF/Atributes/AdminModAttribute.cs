using System.Web.Mvc;
using PlatformCTF.Domains.Enums;
using PlatformCTF.Web.Controllers;

namespace PlatformCTF.Atributes
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authCookie = filterContext.HttpContext.Request.Cookies["X-KEY"];
        
            if (authCookie != null)
            {
                string authToken = authCookie.Value;
                var login = new LoginController();
                var currentUser = login.GetUserDetails(authToken);
            
                if (currentUser == null || currentUser.Level != URole.Admin)
                {
                    filterContext.Result = new RedirectResult("~/Unauthorized/Index");
                    return;
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
                return;
            }
        
            base.OnActionExecuting(filterContext);
        }
    }
}