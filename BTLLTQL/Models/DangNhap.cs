using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    public class DangNhap
    {
        [Key]
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }
}