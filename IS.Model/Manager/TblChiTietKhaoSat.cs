using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblChiTietKhaoSat
    {
        public int MaChiTietKhaoSat { get; set; }
        public int? MaKhaoSat { get; set; }
        public int? MaCauHoi { get; set; }
        public int? MaLuaChon { get; set; }
        public DateTime? ThoiGianTraLoi { get; set; }
        public string GiaTriNhap { get; set; }
        public int? TrangThai { get; set; }

        //public virtual TblCauHoi MaCauHoiNavigation { get; set; }
        //public virtual TblKhaoSat MaKhaoSatNavigation { get; set; }
        //public virtual TblLuaChon MaLuaChonNavigation { get; set; }

        //public virtual TblCauHoi MaCauHoiNavigation { get; set; }
        //public virtual TblKhaoSat MaKhaoSatNavigation { get; set; }
    }
}
