using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblTraLoiLuaChon
    {
        public int MaTraLoiDaLuaChon { get; set; }
        public int? MaChiTietKhaoSat { get; set; }
        public int? MaLuaChon { get; set; }

       // public virtual TblLuaChon MaLuaChonNavigation { get; set; }
    }
}
