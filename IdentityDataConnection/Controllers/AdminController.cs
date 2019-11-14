using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai11.Models;
using System.Data.Entity;

namespace IdentityDataConnection.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private QLBaiVietDB db = new QLBaiVietDB();
        // GET: Admin
        public ActionResult Index()
        {

            return View(db.BaiViets.ToList());
        }
        public ActionResult DetailWrite(int id)
        {
            BaiViet temp = db.BaiViets.FirstOrDefault(x => x.MaBV == id);
            if (temp != null)
                return View(temp);
            else return HttpNotFound();
        }
        public ActionResult AddWrite()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiBaiViets, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult AddWrite(BaiViet bv)
        {
            if (ModelState.IsValidField("NoiDungTT") && ModelState.IsValidField("NoiDungChinh") && ModelState.IsValidField("TuaBV") && ModelState.IsValidField("MaLoai"))
            {
                bv.NgayDang = DateTime.Now;
                db.BaiViets.Add(bv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MaLoai = new SelectList(db.LoaiBaiViets, "MaLoai", "TenLoai");
                return View(bv);
            }
        }
        public ActionResult EditWrite(int id)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiBaiViets, "MaLoai", "TenLoai");
            BaiViet temp = db.BaiViets.FirstOrDefault(x => x.MaBV == id);
            if (temp != null)
                return View(temp);
            else return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditWrite(BaiViet bv)
        {
            if (ModelState.IsValidField("NoiDungTT") && ModelState.IsValidField("NoiDungChinh") && ModelState.IsValidField("TuaBV") && ModelState.IsValidField("MaLoai"))
            {
                db.Entry(bv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MaLoai = new SelectList(db.LoaiBaiViets, "MaLoai", "TenLoai");
                return View(bv);
            }
        }
        public ActionResult DeleteWrite(int id)
        {
            BaiViet temp = db.BaiViets.FirstOrDefault(x => x.MaBV == id);
            if (temp != null)
                return View(temp);
            else return HttpNotFound();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}