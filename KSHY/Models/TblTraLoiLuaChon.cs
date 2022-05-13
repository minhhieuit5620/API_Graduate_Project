using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblTraLoiLuaChon
    {
        public int MaTraLoiDaLuaChon { get; set; }
        public int? MaChiTietKhaoSat { get; set; }
        public int? MaLuaChon { get; set; }
        public int? TrangThai { get; set; }

        public virtual TblChiTietKhaoSat MaChiTietKhaoSatNavigation { get; set; }
        public virtual TblLuaChon MaLuaChonNavigation { get; set; }
    }
}
