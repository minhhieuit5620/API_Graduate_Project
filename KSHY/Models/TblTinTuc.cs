using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblTinTuc
    {
        public int MaTinTuc { get; set; }
        public int? MaLoaiTin { get; set; }
        public string TieuDe { get; set; }
        public string Mota { get; set; }
        public string HinhAnh { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }
    }
}
