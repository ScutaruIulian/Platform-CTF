using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PlatformCTF.BusinessLogic.DBModel.Seed;

namespace Platform_CTF
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_BeginRequest()
        {
            var cookie = Request.Cookies["X-KEY"];
            if (cookie != null)
            {
                using (var db = new UserContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == cookie.Value);
                    if (user != null && user.IsBanned && user.BanEndTime > DateTime.Now)
                    {
                        Response.Redirect("~/Views/Home/Login.cshtml");
                        return;
                    }
                }
            }
        }
    }
}