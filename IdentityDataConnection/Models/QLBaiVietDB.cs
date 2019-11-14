using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Bai11.Models
{
    public class QLBaiVietDB : DbContext
    {
        public QLBaiVietDB() : base("name=QLBaiVietDB") { }
        public DbSet<BaiViet> BaiViets { set; get; }
        public DbSet<LoaiBaiViet> LoaiBaiViets { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<TaiKhoan> TaiKhoans { set; get; }
    }
}