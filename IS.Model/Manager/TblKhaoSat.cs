using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblKhaoSat
    {
        //public TblKhaoSat()
        //{
        //    TblChiTietKhaoSats = new HashSet<TblChiTietKhaoSat>();
        //}

        public int MaKhaoSat { get; set; }
        public int? MaDoanhNghiep { get; set; }
        public DateTime? NgayDanhGia { get; set; } 
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }
        public int? MaDotKhaoSat { get; set; }
        public int? TrangThai { get; set; }

        //public virtual TblDoanhNghiep MaDoanhNghiepNavigation { get; set; }
        //public virtual TblDotKhaoSat MaDotKhaoSatNavigation { get; set; }
        //public virtual ICollection<TblChiTietKhaoSat> TblChiTietKhaoSats { get; set; }
    }
}
