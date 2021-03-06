using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblKhaoSat
    {       
        public int MaKhaoSat { get; set; }
        public int? MaDoanhNghiep { get; set; }
        public DateTime? NgayDanhGia { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }
        public int? MaDotKhaoSat { get; set; }
        public int? TrangThai { get; set; }
    }
}
