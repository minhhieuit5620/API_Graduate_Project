using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblChiTietKhaoSat
    {
        public TblChiTietKhaoSat()
        {
            TblTraLoiLuaChons = new HashSet<TblTraLoiLuaChon>();
        }

        public int MaChiTietKhaoSat { get; set; }
        public int? MaKhaoSat { get; set; }
        public int? MaCauHoi { get; set; }
        public DateTime? ThoiGianTraLoi { get; set; }
        public string GiaTriNhap { get; set; }
        public int? TrangThai { get; set; }

        public virtual TblCauHoi MaCauHoiNavigation { get; set; }
        public virtual TblKhaoSat MaKhaoSatNavigation { get; set; }
        public virtual ICollection<TblTraLoiLuaChon> TblTraLoiLuaChons { get; set; }
    }
}
