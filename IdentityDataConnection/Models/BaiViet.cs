using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai11.Models
{
    [Table("BaiViet")]
    public class BaiViet
    {
        private int maBV;
        private string tuaBV;
        private string noiDungTT;
        private string noiDungChinh;
        private DateTime ngayDang;
        private int maLoai;
        public virtual LoaiBaiViet LoaiBaiViet { set; get; }
        public virtual ICollection<Comment> Comments { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBV
        {
            get
            {
                return maBV;
            }

            set
            {
                maBV = value;
            }
        }
        [Display(Name ="Tựa bài viết")]
        [Required(ErrorMessage = "Vui lòng nhập tựa bài viết")]
        public string TuaBV
        {
            get
            {
                return tuaBV;
            }

            set
            {
                tuaBV = value;
            }
        }
        [Display(Name = "Nội dung tóm tắt")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung tóm tắt bài viết")]
        public string NoiDungTT
        {
            get
            {
                return noiDungTT;
            }

            set
            {
                noiDungTT = value;
            }
        }
        [UIHint("CkEditor")]
        [Display(Name = "Nội dung chính")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung tóm chính bài viết")]
        [AllowHtml]
        public string NoiDungChinh
        {
            get
            {
                return noiDungChinh;
            }

            set
            {
                noiDungChinh = value;
            }
        }
        [Display(Name = "Ngày đăng")]
        [HiddenInput(DisplayValue = false)]
        public DateTime NgayDang
        {
            get
            {
                return ngayDang;
            }

            set
            {
                ngayDang = value;
            }
        }

        public int MaLoai
        {
            get
            {
                return maLoai;
            }

            set
            {
                maLoai = value;
            }
        }
    }
}