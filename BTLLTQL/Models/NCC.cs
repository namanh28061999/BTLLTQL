using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    public class NCC
    {
        [Key]
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string TenHang { get; set; }
        public string Diachi { get; set; }
        public string SoDienThoai { get; set; }

    }
}