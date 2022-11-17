using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThienLongBook.Models;


namespace ThienLongBook.Controllers
{
    public class HomeController : Controller
    {
        ThienLongBookEntities data = new ThienLongBookEntities();
       public ActionResult Index()
        {
            var dsSach = from s in data.Saches select s;
            return View(dsSach.ToList());
        }
       public ActionResult ChuDe()
        {
            var ds = from s in data.ChuDes select s;
            return PartialView(ds.ToList());
        }
    }
}