using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN213_DoAn.Models;

namespace TN213_DoAn.Controllers
{
    public class XaPhuongController : Controller
    {
        ATM_Data db = new ATM_Data();
        // GET: XaPhuong
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getDB()
        {
            List<XAPHUONG> data = db.XAPHUONGs.ToList();
            var res = data.Select(s => new { id = s.MAXP, name = s.TENXP });
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getDB(int id)
        {
            List<XAPHUONG> data = db.XAPHUONGs.Where(s => s.MAQH == id).ToList();
            var res = data.Select(s => new { id = s.MAXP, name = s.TENXP });
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}