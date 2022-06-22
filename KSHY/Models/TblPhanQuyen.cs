using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblPhanQuyen
    {
        //public TblPhanQuyen()
        //{
        //    TblAdmins = new HashSet<TblAdmin>();
        //    TblDoanhNghieps = new HashSet<TblDoanhNghiep>();
        //}

        public int MaQuyen { get; set; }
        public string ChucVu { get; set; }
        public string Mota { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }

        //public virtual ICollection<TblAdmin> TblAdmins { get; set; }
        //public virtual ICollection<TblDoanhNghiep> TblDoanhNghieps { get; set; }
    }
}
