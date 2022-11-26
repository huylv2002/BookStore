using System.Web.Mvc;

namespace ThienLongBook.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
                context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                 new {controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "ThienLongBook.Areas.Admin.Controllers" });

                context.MapRoute(
              "Admin_Login",
              "Admin/{controller}/{action}/{id}",
               new { controller = "UserAd", action = "Login", id = UrlParameter.Optional }, new[] { "ThienLongBook.Areas.Admin.Controllers" });

            context.MapRoute(
            "Admin_CapNhat",
            "Admin/{controller}/{action}/{id}",
             new { controller = "Home", action = "CapNhatKhachHang", id = UrlParameter.Optional }, new[] { "ThienLongBook.Areas.Admin.Controllers" });
        }
    }
}