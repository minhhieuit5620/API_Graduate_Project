using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblLuaChon
    {
        //public TblLuaChon()
        //{
        //    TblTraLoiLuaChons = new HashSet<TblTraLoiLuaChon>();
        //}

        public int MaLuaChon { get; set; }
        public int? MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public int? TrangThai { get; set; }

        //public virtual TblCauHoi MaCauHoiNavigation { get; set; }
        //public virtual ICollection<TblTraLoiLuaChon> TblTraLoiLuaChons { get; set; }
    }
}
