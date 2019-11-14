using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bai11.Models
{
    [Table("LoaiBaiViet")]
    public class LoaiBaiViet
    {
        private int maLoai;
        private string tenLoai;
        public virtual ICollection<BaiViet> BaiViets { set; get; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Display(Name = "Loại bài viết")]
        [Required(ErrorMessage = "Vui lòng nhập loại bài viết")]
        public string TenLoai
        {
            get
            {
                return tenLoai;
            }

            set
            {
                tenLoai = value;
            }
        }
    }
}