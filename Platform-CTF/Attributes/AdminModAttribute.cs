using System.Web.Mvc;
using System.Web.Routing;
using Platform_CTF.Controllers;
using PlatformCTF.Domains.Enums;

namespace Platform_CTF.Attributes
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authCookie = filterContext.HttpContext.Request.Cookies["X-KEY"];

            if (authCookie != null)
            {
                var authToken = authCookie.Value;
                var login = new LoginController();
                var currentUser = login.GetUserDetails(authToken);

                if (currentUser == null || currentUser.Level != URole.Admin)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                            { "controller", "Login" },
                            { "action", "Login" },
                            { "errorMessage", "You are not authorized to access this page." }
                        });
                    return;
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Login" },
                        { "errorMessage", "Please login first." }
                    });
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}