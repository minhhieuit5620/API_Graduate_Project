using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblNganhKd
    {
        //public TblNganhKd()
        //{
        //    TblDoanhNghieps = new HashSet<TblDoanhNghiep>();
        //}

        public int MaNganh { get; set; }
        public string TenNganh { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }

       // public virtual ICollection<TblDoanhNghiep> TblDoanhNghieps { get; set; }
    }
}
