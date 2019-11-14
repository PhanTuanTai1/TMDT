using IdentityDataConnection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityDataConnection.Controllers
{
    public class GiaSuOnlineController : Controller
    {
        const double feeService = 0.1;
        public GiaSuOnlineDB db;
        // GET: GiaSuOnline
        public ActionResult Index()
        {
            db = new GiaSuOnlineDB();
            return View();        
        }
        public ActionResult KhoaHoc()
        {
            db = new GiaSuOnlineDB();
            return View(db.LopHocs);
        }
        [Authorize]
        public ActionResult DangKy(int id)
        {
            db = new GiaSuOnlineDB();
            LopHoc lh = db.LopHocs.SingleOrDefault(x => x.MaLH == id);
            return View(lh);
        }
        [Authorize]
        
        public ActionResult DangKyKhoaHoc()
        {
            int id = int.Parse(Request.QueryString["id"]);
            string MaGS = Request.QueryString["MaGS"];
            ApplicationDbContext dbIdentity = new ApplicationDbContext();
            string idAdmin = dbIdentity.Users.SingleOrDefault(x => x.UserName == "Admin").Id;
            string idIdentity = dbIdentity.Users.SingleOrDefault(x => x.UserName == User.Identity.Name).Id;
            db = new GiaSuOnlineDB();
            User u = db.Users.SingleOrDefault(x => x.id == idIdentity);
            User admin = db.Users.SingleOrDefault(x => x.id == idAdmin);
            User GS = db.Users.SingleOrDefault(x => x.id == MaGS);
            LopHoc lh = db.LopHocs.SingleOrDefault(x => x.MaLH == id);
            if(u.balance < lh.Gia) return Json(new { result = "Không đủ số dư để đăng ký môn học"}, JsonRequestBehavior.AllowGet);
            else
            {
                double gia = lh.Gia + lh.Gia * feeService;
                u.balance -= gia;
                ThanhToan t = new ThanhToan()
                {
                    SoTienTT = gia,
                    MaLH = lh.MaLH,
                    MaNH = u.id
                };
                GS.balance += lh.Gia - lh.Gia * feeService;
                admin.balance += (lh.Gia * feeService)*2;
                db.ThanhToans.Add(t);
                db.SaveChanges();
            }
            return PartialView("DangKyThanhCong");
        }
    }
}