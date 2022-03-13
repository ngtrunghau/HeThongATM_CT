using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN213_DoAn.Models;

namespace TN213_DoAn.Controllers
{
    public class NganHangController : Controller
    {
        ATM_Data db = new ATM_Data();
        // GET: NganHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult getDB_NH()
        {
            List<NGANHANG> data = db.NGANHANGs.ToList();
            var res = data.Select(s => new { id = s.MANH, name = s.TENNH });
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}