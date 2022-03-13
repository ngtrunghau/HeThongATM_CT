using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN213_DoAn.Models;

namespace TN213_DoAn.Controllers
{
    public class QuanHuyenController : Controller
    {
        ATM_Data db = new ATM_Data();
        // GET: QuanHuyen
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getDB()
        {
            List<QUANHUYEN> data = db.QUANHUYENs.ToList();
            var res = data.Select(s => new { id = s.MAQH, name = s.TENQH, polygon = s.POLYGONQH.ProviderValue.ToString()});
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}