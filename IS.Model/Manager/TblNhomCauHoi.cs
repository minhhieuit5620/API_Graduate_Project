using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public class TblNhomCauHoi
    {
     
        public int MaNhomCauHoi { get; set; }
        public string TenNhomCauHoi { get; set; }
        public int? MaTieuChiCha { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }
       
    }
}
