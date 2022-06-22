using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblCauHoi
    {        
        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public string GoiYcauHoi { get; set; }
        public int? MaLoaiCauHoi { get; set; }
        public int? MaNhomCauHoi { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }
        public int? TrangThai { get; set; }
    }
}
