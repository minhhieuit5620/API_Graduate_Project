using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblDoanhNghiep
    {  
        public int MaDoanhNghiep { get; set; }
        public int? MaDinhDanhDn { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenToChuc { get; set; }
        public string DiaChi { get; set; }
        public string TinhThanh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string NguoiKhaoSat { get; set; }
        public int? MaNganh { get; set; }
        public int? MaLoaiHinh { get; set; }
        public string QuyMo { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public int? TrangThai { get; set; }
        public int? Rol { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
}
