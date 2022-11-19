using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThienLongBook.Models;

namespace ThienLongBook.Controllers
{
    public class UserController : Controller
    {
        ThienLongBookEntities data = new ThienLongBookEntities();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var email = f["email"];
            var pass = f["pass"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(s => s.email == email && s.passwordKH == pass);
            if (kh != null)
            {
                Session["nguoiDung"] = kh;
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.thongBao = "Email hoặc Mật khẩu không chính xác, Vui lòng nhập lại!";
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult Index()
        {
            var dsTrongGio = (from s in data.Saches select s).ToList();
            return View(dsTrongGio);
        }

        public ActionResult LoginWas()
        {
            return PartialView();
        }

        public ActionResult LogOut()
        {
            Session["nguoiDung"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}