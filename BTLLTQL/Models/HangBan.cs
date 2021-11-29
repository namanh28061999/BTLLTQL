using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    public class HangBan
    {
        [Key]
        public string  MaHang { get; set; }
        public string  TenHang { get; set; }
        public string  ViTri { get; set; }
        public string  SoLuong { get; set; }
        public string DonGia { get; set; }
        public string ThanhTien { get; set; }
        public string HanSD { get; set; }
        public ICollection<HoaDonBanHang> hoaDonBanHangs { get; set; }


    }
}