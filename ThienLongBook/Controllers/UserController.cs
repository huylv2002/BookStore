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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection f)
        {    
            var hoTen = f["hoTen"].ToString();
            var email = f["email"].ToString();
            var taiKhoan = f["taiKhoanKH"].ToString();
            var matKhau = f["matKhau"].ToString();
            var sdt = f["sdt"].ToString();
            var ngaySinh = f["ngaySinh"].ToString();
            bool gioiTinh;
            if (f["gender"].ToString() == "Nam")
            {
                gioiTinh = true;
            }
            else gioiTinh = false;
            
            string diaChi = f["diaChi"].ToString();
            if(String.IsNullOrEmpty(hoTen))
            {
                ViewBag.hoTenErr = "Họ tên trống";
            }
            else if (String.IsNullOrEmpty(diaChi))
            {
                ViewBag.diaChiErr = "Địa chỉ trống";
            }
            else if (String.IsNullOrEmpty(sdt))
            {
                ViewBag.sdtErr = "Số điện thoại trống";
            }
            else if (String.IsNullOrEmpty(taiKhoan))
            {
                ViewBag.taiKhoanErr = "Tài khoản trống";
            }
            else if (String.IsNullOrEmpty(matKhau))
            {
                ViewBag.matKhauErr = "Mật khẩu trống";
            }
            else if (String.IsNullOrEmpty(ngaySinh.ToString()))
            {
                ViewBag.ngaySinhErr = "Ngày sinh chưa nhập";
            }
            else if (String.IsNullOrEmpty(gioiTinh.ToString()))
            {
                ViewBag.gioiTinhErr = "Giới tính chưa được chọn";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewBag.diaChiErr = "email đang trống";
            }
            else if (data.KhachHangs.SingleOrDefault(n=>n.accountKH == taiKhoan) != null)
            {
                ViewBag.thongBao = "Tài khoản đã tồn tại";
            }
            else if (data.KhachHangs.SingleOrDefault(n => n.email == email) != null)
            {
                ViewBag.thongBao = "email đã tồn tại";
            }
            else
            {
                KhachHang kh = new KhachHang();
                kh.hoTenKH = hoTen;
                kh.diaChiKH = diaChi;
                kh.dienThoaiKH = sdt;
                kh.accountKH = taiKhoan;
                kh.passwordKH = matKhau;
                kh.ngaySinh = DateTime.Parse(ngaySinh);
                kh.gioiTinh = gioiTinh;
                kh.email = email;
                kh.daDuyet = true;
                kh.avatar = null;
                kh.maKH = "KH" + sdt.Substring(6);
                data.KhachHangs.Add(kh);
                data.SaveChanges();
                if (kh != null)
                {
                    return RedirectToAction("Login");
                }
            }
            return this.Register();
        }
    }
}