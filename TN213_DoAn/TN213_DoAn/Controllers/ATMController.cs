using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN213_DoAn.Models;

namespace TN213_DoAn.Controllers
{
    public class ATMController : Controller
    {
        ATM_Data db = new ATM_Data();
        private int temp;
        // GET: ATM
        public ActionResult Create()
        {
            List<XAPHUONG> data_XP = db.XAPHUONGs.ToList();
            List<ANTOAN> data_AT = db.ANTOANs.ToList();
            List<NGANHANG> data_NH = db.NGANHANGs.ToList();
            List<ANHATM> data_ANH = db.ANHATMs.ToList();
            SelectList list_XP = new SelectList(data_XP, "MAXP", "TENXP");
            SelectList list_AT = new SelectList(data_AT, "MAAT", "MUCDOAT");
            SelectList list_NH = new SelectList(data_NH, "MANH", "TENNH");
            SelectList list_ANH = new SelectList(data_ANH, "MAANH", "TENANH");
            ViewBag.listXP = list_XP;
            ViewBag.listAT = list_AT;
            ViewBag.listNH = list_NH;
            ViewBag.listANH = list_ANH;

            return View();
        }
        [HttpPost]
        public ActionResult Create(ATM ATM, string kinhdo, string vido)
        {
            ATM atm = new ATM();
            atm.MAXP = ATM.MAXP;
            atm.MAAT = ATM.MAAT;
            atm.DIACHIATM = ATM.DIACHIATM;
            atm.MANH = ATM.MAANH;
            atm.MANH = ATM.MANH;
            atm.TENATM = ATM.TENATM;
            atm.DONGCUAATM = ATM.DONGCUAATM;
            atm.MOCUAATM = ATM.MOCUAATM;
            atm.POINTATM = DbGeometry.FromText("POINT(" + kinhdo + " " + vido + ")");
            db.ATMs.Add(atm);
            db.SaveChanges();
            /*db.Database.SqlQuery<int>("INSERT INTO ATM(MAXP,MAAT,TENATM,DIACHIATM,SDTATM,MOCUAATM,DONGCUAATM,MANH,MAANH,POINTATM) " +
                                        "VALUES(" + ATM.MAXP + "," + ATM.MAAT + "," + ATM.TENATM + "," + ATM.DIACHIATM + "," + ATM.SDTATM + "," + ATM.MOCUAATM + "," + ATM.DONGCUAATM + "," + ATM.MANH + "," +"geometry::STGeomFromText ('POINT (" + kinhdo + " " + vido +")', 0));");*/
            return RedirectToAction("ATM", "Home");
        }

        public ActionResult Edit(int id)
        {
            temp = id;
            ATM res = db.ATMs.Find(id);
            List<XAPHUONG> data_XP = db.XAPHUONGs.ToList();
            List<ANTOAN> data_AT = db.ANTOANs.ToList();
            List<NGANHANG> data_NH = db.NGANHANGs.ToList();
            List<ANHATM> data_ANH = db.ANHATMs.ToList();
            SelectList list_XP = new SelectList(data_XP, "MAXP", "TENXP");
            SelectList list_AT = new SelectList(data_AT, "MAAT", "MUCDOAT");
            SelectList list_NH = new SelectList(data_NH, "MANH", "TENNH");
            SelectList list_ANH = new SelectList(data_ANH, "MAANH", "TENANH");
            ViewBag.listXP = list_XP;
            ViewBag.listAT = list_AT;
            ViewBag.listNH = list_NH;
            ViewBag.listANH = list_ANH;

            return View(res);
        }

        [HttpPost]
        public ActionResult Edit(int id, ATM ATM, string kinhdo, string vido)
        {
            ATM atm = db.ATMs.Find(id);
            atm.MAXP = ATM.MAXP;
            atm.MAAT = ATM.MAAT;
            atm.DIACHIATM = ATM.DIACHIATM;
            atm.MANH = ATM.MAANH;
            atm.MANH = ATM.MANH;
            atm.TENATM = ATM.TENATM;
            atm.DONGCUAATM = ATM.DONGCUAATM;
            atm.MOCUAATM = ATM.MOCUAATM;
            atm.POINTATM = DbGeometry.FromText("POINT(" + kinhdo + " " + vido + ")");
            db.SaveChanges();
            return RedirectToAction("ATM", "Home");
        }
        public ActionResult Delete(int id)
        {
            ATM data = db.ATMs.Find(id);
            db.ATMs.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ATM", "Home");
        }

        public ActionResult getDB()
        {
            List<ATM> data = db.ATMs.ToList();
            var res = data.Select(s => new { id = s.MAATM, name = s.TENATM, geometry = s.POINTATM.ProviderValue.ToString() });
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getDB_PX(int id)
        {
            List<ATM> data = db.ATMs.Where(s => s.MAXP == id).ToList();
            var res = data.Select(s => new { id = s.MAATM, name = s.TENATM, geometry = s.POINTATM.ProviderValue.ToString() });
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getDB_QH(int id)
        {
            List<ATM> data = db.ATMs.Where(s => s.XAPHUONG.QUANHUYEN.MAQH == id).ToList();
            var res = data.Select(s => new { id = s.MAATM, name = s.TENATM, geometry = s.POINTATM.ProviderValue.ToString() });
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getDB_NH(int id)
        {
            List<ATM> data = db.ATMs.Where(s => s.MANH == id).ToList();
            var res = data.Select(s => new { id = s.MAATM, name = s.TENATM, geometry = s.POINTATM.ProviderValue.ToString() });
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}