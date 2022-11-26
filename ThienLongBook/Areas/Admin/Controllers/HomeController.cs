using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThienLongBook.Models;

namespace ThienLongBook.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ThienLongBookEntities data = new ThienLongBookEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "UserAd");
            }
            ViewBag.tongDonHang = TongDonHang();
            TempData["DonHang"] = DonDatHang();

            return View();
        }

        public double TongDonHang()
        {
            double tong = 0;
            List<DonDatHang> donHang = (from s in data.DonDatHangs select s).ToList();
             tong = double.Parse(donHang.Sum(n=>n.triGia).ToString());
            return tong;
        }

        public List<DonDatHang> DonDatHang()
        {
            List<DonDatHang> donDH = (from s in data.DonDatHangs select s).ToList();
            return donDH;
        }
        
        public List<KhachHang> DsKhachHang()
        {
            List<KhachHang> dsKh = (from s in data.KhachHangs select s).ToList();
            return dsKh;
        }

        public ActionResult CapNhatKhachHang()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "UserAd");
            }
            TempData["KhachHang"] = DsKhachHang();
            return View();
        }
    }
}