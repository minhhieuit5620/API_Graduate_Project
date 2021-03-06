using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblTaiKhoanDn
    {
        public int MaTaiKhoan { get; set; }
        public int MaToChuc { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int? Rol { get; set; }
        public int? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }
    }
}
