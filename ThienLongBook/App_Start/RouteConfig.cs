using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ThienLongBook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Book",
                url: "{controller}/{action}/{page}",
                new { controller = "Book", action = "Index", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BookCD",
                url: "{controller}/{action}/{maCD}",
                new { controller = "Book", action = "SachChuDe", maCD = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BookNXB",
                url: "{controller}/{action}/{maCD}",
                new { controller = "Book", action = "SachNXB", maNXB = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "BookChitiet",
                url: "{controller}/{action}/{maSach}",
                new { controller = "Book", action = "SachChiTiet", maSach = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GioHang",
                url: "{controller}/{action}/{maSach}",
                new { controller = "Cart", action = "GioHang", maSach = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "DatHang",
                url: "{controller}/{action}",
                new { controller = "Cart", action = "DatHang"}
            );
        }
    }
}
