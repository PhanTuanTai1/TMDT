using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bai11.Models
{
    public class DataInitial : CreateDatabaseIfNotExists<QLBaiVietDB>
    {
        protected override void Seed(QLBaiVietDB context)
        {
            context.LoaiBaiViets.Add(new LoaiBaiViet { TenLoai = "Công nghệ thông tin" });
            context.LoaiBaiViets.Add(new LoaiBaiViet { TenLoai = "Kinh tế" });
            context.LoaiBaiViets.Add(new LoaiBaiViet { TenLoai = "Truyện cười" });
            context.LoaiBaiViets.Add(new LoaiBaiViet { TenLoai = "Tài chính ngân hàng" });
            context.SaveChanges();
            context.BaiViets.Add(new BaiViet { TuaBV = "Java", NoiDungTT = "Java (phiên âm Tiếng Việt: 'Gia - va') là một ngôn ngữ lập trình hướng đối tượng (OOP) và dựa trên các lớp (class)[9]. Khác với phần lớn ngôn ngữ lập trình thông thường, thay vì biên dịch mã nguồn thành mã máy hoặc thông dịch mã nguồn khi chạy, Java được thiết kế để biên dịch mã nguồn thành bytecode, bytecode sau đó sẽ được môi trường thực thi (runtime environment) chạy.", NoiDungChinh = "Trước đây, Java chạy chậm hơn những ngôn ngữ dịch thẳng ra mã máy như C và C++, nhưng sau này nhờ công nghệ 'biên dịch tại chỗ' - Just in time compilation, khoảng cách này đã được thu hẹp, và trong một số trường hợp đặc biệt Java có thể chạy nhanh hơn. Java chạy nhanh hơn những ngôn ngữ thông dịch như Python, Perl, PHP gấp nhiều lần. Java chạy tương đương so với C#, một ngôn ngữ khá tương đồng về mặt cú pháp và quá trình dịch/chạy", MaLoai = 1, NgayDang = DateTime.Now.Date });
            base.Seed(context);
        }
    }
}