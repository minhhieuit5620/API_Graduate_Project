using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblPhanQuyen
    {
        //public TblPhanQuyen()
        //{
        //    TblAdmins = new HashSet<TblAdmin>();
        //    TblTaiKhoanDns = new HashSet<TblTaiKhoanDn>();
        //}

        public int MaQuyen { get; set; }
        public string ChucVu { get; set; }

        //public virtual ICollection<TblAdmin> TblAdmins { get; set; }
        //public virtual ICollection<TblTaiKhoanDn> TblTaiKhoanDns { get; set; }
    }
}
