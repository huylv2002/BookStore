using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThienLongBook.Models;

namespace ThienLongBook.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ThienLongBookEntities data = new ThienLongBookEntities();
        public List<GioHang> TrongGio()
        {
            List<GioHang> dsTrongGio = Session["dsTrongGio"] as List<GioHang>;
            if(dsTrongGio == null)
            {
                dsTrongGio = new List<GioHang>();
                Session["dsTrongGio"] = dsTrongGio;
            }
            return dsTrongGio;
        }

        public ActionResult ThemVaoGio(int maSach, string url)
        {
            List<GioHang> dsTrongGio = TrongGio();
            GioHang sp = dsTrongGio.Find(x => x.iMaSach == maSach);
            if(sp == null)
            {
                sp = new GioHang(maSach);
                dsTrongGio.Add(sp);
            }
            else
            {
                sp.iSoLuong++;
            }
            return Redirect(url);
        }

        public int TongSoLuong()
        {
            int iTongSoluong = 0;
            List<GioHang> dsTrongGio = Session["dsTrongGio"] as List<GioHang>;
            if(dsTrongGio != null)
            {
                iTongSoluong = dsTrongGio.Sum(n => n.iSoLuong);
            }
            return iTongSoluong;
 
        }

        public double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> dsTrongGio = Session["dsTrongGio"] as List<GioHang>;
            if(dsTrongGio != null)
            {
                iTongTien = dsTrongGio.Sum(n => n.dThanhToan);
            }
            return iTongTien;
        }

        public ActionResult GioHang()
        {
            List<GioHang> dsTrongGio = TrongGio();
            if(dsTrongGio.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag["tongSoLuong"] = TongSoLuong();
            ViewBag["tongTien"] = TongTien();
            return View(dsTrongGio);
        }




    }
}