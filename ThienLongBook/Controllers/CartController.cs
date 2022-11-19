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

        public ActionResult GiamSoLuong(int maSach)
        {
            List<GioHang> dsTrongGio = TrongGio();
            GioHang sp = dsTrongGio.Find(x => x.iMaSach == maSach);
            if (sp == null)
            {
                sp = new GioHang(maSach);
                dsTrongGio.Add(sp);
            }
            else
            {
                sp.iSoLuong--;
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult TangSoLuong(int maSach)
        {
            List<GioHang> dsTrongGio = TrongGio();
            GioHang sp = dsTrongGio.Find(x => x.iMaSach == maSach);
            if (sp == null)
            {
                sp = new GioHang(maSach);
                dsTrongGio.Add(sp);
            }
            else
            {
                sp.iSoLuong++;
            }
            return RedirectToAction("GioHang");
        }

        public int TongSoLuong()
        {
            int iTongSoluong = 0;
            List<GioHang> dsTrongGio = Session["dsTrongGio"] as List<GioHang>;
            if(dsTrongGio != null)
            { 
                iTongSoluong = dsTrongGio.Sum(n => n.iSoLuong);
            }
            ViewBag.tongSoLuong = iTongSoluong;
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

        public double TongTienTT()
        {
            double iTongTien = 0;
            List<GioHang> dsTrongGio = Session["dsTrongGio"] as List<GioHang>;
            double phiVanChuyen = (dsTrongGio.Sum(n => n.dThanhToan) / 100)*10;
            if (dsTrongGio != null)
            {
                iTongTien = dsTrongGio.Sum(n => n.dThanhToan)+ phiVanChuyen;
            }
            return iTongTien;
        }

        public ActionResult GioHang()
        {
            if(Session["nguoiDung"] == null)
            {
                return RedirectToAction("Login","User");
            }
            List<GioHang> dsTrongGio = TrongGio();
            if(dsTrongGio.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.tongSoLuong = TongSoLuong();
            ViewBag.tongTien = TongTien();
            ViewBag.tongTienThanhToan = TongTienTT();
            return View(dsTrongGio);
        }

        public ActionResult GioHangPartial()
        {
            List<GioHang> dsTrongGio = TrongGio();
            if(dsTrongGio == null)
            {
                ViewBag.tongSoLuong = 0; ;
                ViewBag.tongTien = 0;
            }
            else
            {
                ViewBag.tongSoLuong = TongSoLuong();
                ViewBag.tongTien = TongTien();
            }
            return PartialView(dsTrongGio);
        }

        public ActionResult XoaTrongGio(int maSach)
        {
            List<GioHang> dsTronGio = TrongGio();
            GioHang sp = dsTronGio.SingleOrDefault(n => n.iMaSach == maSach);
            if(sp != null)
            {
                dsTronGio.RemoveAll(n => n.iMaSach == maSach);
                if (dsTronGio.Count() == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaTrongGio()
        {
            Session["dsTrongGio"] = null;
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            DonDatHang ddh = new DonDatHang();
            KhachHang kh = Session["nguoiDung"] as KhachHang;
            List<GioHang> dsTrongGio = TrongGio();
            ddh.maKH = kh.maKH;
            ddh.ngayDH = DateTime.Now;
            ddh.triGia = decimal.Parse(TongTienTT().ToString());
            ddh.daGiao = false;
            var ngayGD = DateTime.Now;
            ddh.ngayGiaoHang =  ngayGD.AddDays(5);
            ddh.tenNguoiNhan = kh.hoTenKH;
            if (f["diaChiNhan"] == null || f["diaChiNhan"] == "")
            {
                ddh.diaChiNhan = kh.diaChiKH;
            } else ddh.diaChiNhan = f["diaChiNhan"].ToString();

            ddh.dienThoaiNhan = kh.dienThoaiKH;
            ddh.hTThanhtoan = true;
            ddh.hTGiaoHang = true;
            data.DonDatHangs.Add(ddh);
            foreach (var ind in dsTrongGio)
            {
                Random rnd = new Random();
                ChiTietDatHang ctDH = new ChiTietDatHang();
                ctDH.maCTHD = rnd.Next(1, 1000).ToString();
                ctDH.soDH = ddh.soDH;
                ctDH.maSach = ind.iMaSach;
                ctDH.soLuong = ind.iSoLuong;
                ctDH.giaBan = decimal.Parse(ind.dDonGia.ToString());
                data.ChiTietDatHangs.Add(ctDH);
                data.SaveChanges();
            }
            data.SaveChanges();
            Session["dsTrongGio"] = null;
            return RedirectToAction("XacNhanDon","Cart");
        }

        public ActionResult XacNhanDon()
        {
            return View();
        }
    }
}