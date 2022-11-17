using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThienLongBook.Models;
using PagedList;
using PagedList.Mvc;

namespace ThienLongBook.Controllers
{
    public class BookController : Controller
    {
        ThienLongBookEntities data = new ThienLongBookEntities();
        // GET: Sach
        public ActionResult Index(int? page = 1)
        {
            int iSize = 10;
            int iPageNum = (page ?? 1);
            TempData["dsChuDe"] = (from s in data.ChuDes select s).ToList();
            var dsSach = (from s in data.Saches select s).ToList();
            return View(dsSach.ToPagedList(iPageNum, iSize));
        }
        
        public ActionResult SachChuDe(string maCD ,int? page = 1)
        {
            int iSize = 10;
            int iPageNum = (page ?? 1);
            TempData["dsChuDe"] = (from s in data.ChuDes select s).ToList();
            var dsSach = (from s in data.Saches where s.maCD == maCD select s).ToList();
            return View(dsSach.ToPagedList(iPageNum, iSize));
        }

        public ActionResult SachNXB(string maNXB, int? page = 1)
        {
            int iSize = 10;
            int iPageNum = (page ?? 1);
            TempData["dsChuDe"] = (from s in data.ChuDes select s).ToList();
            var dsSach = (from s in data.Saches where s.maNXB == maNXB select s).ToList();
            return View(dsSach.ToPagedList(iPageNum, iSize));
        }

        public ActionResult SachChiTiet(int maSach)
        {
            TempData["dsSach"] = (from s in data.Saches select s).ToList();
            var dsSach = (from s in data.Saches where s.maSach == maSach select s).SingleOrDefault();
            return View(dsSach);
        }
    }
}