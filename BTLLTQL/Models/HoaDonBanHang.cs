using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLLTQL.Models
{
    public class HoaDonBanHang
    {
        [Key]
        public string MaHoaDon { get; set; }
        public string NgayBan { get; set; }
        public string MaHang { get; set; }
        public HangBan HangBan { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public string ThanhTien { get; set; }
       

    }
}