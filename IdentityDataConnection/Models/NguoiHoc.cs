using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDataConnection.Models
{
    public class NguoiHoc
    {
        [Key]
        public string IdNH { get; set; }
        public string TenNH { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public List<ThanhToan> ThanhToans { get; set; }
    }
}
