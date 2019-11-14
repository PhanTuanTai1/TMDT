using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai11.Models
{
    [Table("Comment")]
    public class Comment
    {
        private int maComment;
        private string noiDung;
        private DateTime ngayComment;
        private int maBaiViet;
        private int maTaiKhoan;
        public virtual BaiViet BaiViet { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaComment
        {
            get
            {
                return maComment;
            }

            set
            {
                maComment = value;
            }
        }
        [Required(ErrorMessage = "Vui lòng nhập nội dung comment")]
        public string NoiDung
        {
            get
            {
                return noiDung;
            }

            set
            {
                noiDung = value;
            }
        }
        [HiddenInput(DisplayValue = true)]
        public DateTime NgayComment
        {
            get
            {
                return ngayComment;
            }

            set
            {
                ngayComment = value;
            }
        }
        [HiddenInput(DisplayValue = false)]
        public int MaBaiViet
        {
            get
            {
                return maBaiViet;
            }

            set
            {
                maBaiViet = value;
            }
        }
        [HiddenInput(DisplayValue = false)]
        public int MaTaiKhoan
        {
            get
            {
                return maTaiKhoan;
            }

            set
            {
                maTaiKhoan = value;
            }
        }
    }
}