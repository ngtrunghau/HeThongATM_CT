using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN213_DoAn.Models;

namespace TN213_DoAn.Controllers
{
    public class HomeController : Controller
    {
        ATM_Data db = new ATM_Data();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ATM()
        {
            List<ATM> data = db.ATMs.ToList();
            return View(data);
        }
        public ActionResult Bank()
        {
            List<NGANHANG> data = db.NGANHANGs.ToList();
            return View(data);
        }
    }
}