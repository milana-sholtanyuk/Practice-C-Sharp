using System.Web.Mvc;
using System.Web.Routing;

namespace GuestBookApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Маршрут для книги отзывов
            routes.MapRoute(
                name: "GuestRecent",
                url: "Guest/Recent",
                defaults: new { controller = "Guest", action = "Recent" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}