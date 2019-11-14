using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai11.Models;
namespace Bai11.Controllers
{
    public class PostController : Controller
    {
        private QLBaiVietDB db = new QLBaiVietDB();
        // GET: Post
        public ActionResult Index()
        {
            return View("_Write", db.BaiViets.ToList());
        }
        public ActionResult AllType()
        {
            return PartialView("_AllType",db.LoaiBaiViets.ToList());
        }
        public ActionResult Comment(int id)
        {
            ViewBag.MaBV = id;
            return PartialView("Comment",db.Comments.Where(x=>x.MaBaiViet == id).ToList());
        }
        private Comment CreateComment(int id,string noidung,int idus)
        {
            Comment cmt = new Comment()
            {
                MaBaiViet = id,
                MaTaiKhoan = idus,
                NoiDung = noidung,
                NgayComment = DateTime.Now
            };
            return cmt;
        }
        private TaiKhoan CreateTaiKhoan(string username)
        {
            TaiKhoan tk = new TaiKhoan()
            {
                TenDayDu = username,
                LoaiTaiKhoan = -1
            };
            return tk;
        }
        [HttpPost]
        public ActionResult Comment(int id, string noidung, string emailCmt)
        {
            TaiKhoan temp = db.TaiKhoans.FirstOrDefault(x => x.TenDayDu == emailCmt);
            if (temp != null)
            {
                if (!string.IsNullOrEmpty(noidung))
                {                   
                    db.Comments.Add(CreateComment(id,noidung,temp.MaTaiKhoan));
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("noidung", "Vui lòng nhập nội dung bình luận");
                    return RedirectToAction("Detail", "Post", new { id = id });
                }
            }
            else
            {
                if(!string.IsNullOrEmpty(emailCmt))
                {
                    
                    db.TaiKhoans.Add(CreateTaiKhoan(emailCmt));
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("emailCmt", "Vui lòng nhập địa chỉ email");
                    return RedirectToAction("Detail", "Post", new { id = id });
                }
                if (!string.IsNullOrEmpty(noidung))
                {
                    //TaiKhoan temp = db.TaiKhoans.FirstOrDefault(x => x.TenDayDu == emailCmt);
                    db.Comments.Add(CreateComment(id, noidung, temp.MaTaiKhoan));
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("noidung", "Vui lòng nhập nội dung bình luận");
                    return RedirectToAction("Detail", "Post", new { id = id });
                }
            }
            return RedirectToAction("Detail", "Post", new { id = id });
        }
        
        public ActionResult AllWrites()
        {
            return View("_Write", db.BaiViets.ToList());
        }
        public ActionResult Write(int id)
        {
            List<BaiViet> lst = db.BaiViets.Where(x => x.MaLoai == id).ToList();
            string loai = db.LoaiBaiViets.FirstOrDefault(x => x.MaLoai == id).TenLoai;
            ViewBag.Loai = loai;
            if (lst.Count == 0) return View("NotFoundWrite");
            return View("_Write", lst);
        }
        public ActionResult Detail(int id)
        {
            BaiViet temp = db.BaiViets.FirstOrDefault(x => x.MaBV == id);
            if (temp == null) return HttpNotFound();
            return View("_Detail", temp);
        }
        public ActionResult Login()
        {
            return PartialView();
        }
    }
}