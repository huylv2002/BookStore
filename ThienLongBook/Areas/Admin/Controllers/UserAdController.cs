using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThienLongBook.Models;
namespace ThienLongBook.Areas.Admin.Controllers
{
    public class UserAdController : Controller
    {
        ThienLongBookEntities data = new ThienLongBookEntities();
        // GET: Admin/User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string email = f["email"].ToString();
            string matKhau = f["matKhau"].ToString();
            ADMIN kh = data.ADMINs.SingleOrDefault(s => s.emailAdmin == email && s.passwordAdmin == matKhau);

            if(kh != null)
            {
                Session["Admin"] = kh;
                return RedirectToAction("Index","Home");
            }
            return View("Login");
        }
    }
}