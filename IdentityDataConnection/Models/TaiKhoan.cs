using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bai11.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        private int maTaiKhoan;
        private string tenDayDu;
        private int loaiTaiKhoan;
        private string email;
        public virtual ICollection<Comment> Comments { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public string TenDayDu
        {
            get
            {
                return tenDayDu;
            }

            set
            {
                tenDayDu = value;
            }
        }

        public int LoaiTaiKhoan
        {
            get
            {
                return loaiTaiKhoan;
            }

            set
            {
                loaiTaiKhoan = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}