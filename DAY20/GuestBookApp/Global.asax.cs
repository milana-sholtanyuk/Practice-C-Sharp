using GuestBookApp.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace GuestBookApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DbInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}