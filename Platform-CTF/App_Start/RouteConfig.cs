using System.Web.Mvc;
using System.Web.Routing;

namespace Platform_CTF
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Landing", id = UrlParameter.Optional }
            );
        }
    }
}