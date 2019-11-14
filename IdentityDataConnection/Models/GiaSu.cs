using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDataConnection.Models
{
    public class GiaSu
    {
        [Key]
        public string MaGS { get; set; }
        public string TenGS { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public virtual List<LopHoc> LopHocs { get; set; }
    }
}
