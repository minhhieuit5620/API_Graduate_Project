using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblTinTucLoai
    {
        public int MaLoaiTinTuc { get; set; }
        public string TieuDeLoaiTin { get; set; }
        public string MotaLoaiTin { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }
    }
}
