using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblCauHoi
    {
        public TblCauHoi()
        {
            TblChiTietKhaoSats = new HashSet<TblChiTietKhaoSat>();
            TblLuaChons = new HashSet<TblLuaChon>();
        }

        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public string GoiYcauHoi { get; set; }
        public int? MaLoaiCauHoi { get; set; }
        public int? MaNhomCauHoi { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }

        public virtual TblLoaiCauHoi MaLoaiCauHoiNavigation { get; set; }
        public virtual TblNhomCauHoi MaNhomCauHoiNavigation { get; set; }
        public virtual ICollection<TblChiTietKhaoSat> TblChiTietKhaoSats { get; set; }
        public virtual ICollection<TblLuaChon> TblLuaChons { get; set; }
    }
}
