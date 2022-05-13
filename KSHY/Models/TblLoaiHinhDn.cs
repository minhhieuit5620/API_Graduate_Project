using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblLoaiHinhDn
    {
        public TblLoaiHinhDn()
        {
            TblDoanhNghieps = new HashSet<TblDoanhNghiep>();
        }

        public int MaLoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }
        public int? TrangThai { get; set; }
        public string NguoiThem { get; set; }
        public DateTime? NgayThem { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }

        public virtual ICollection<TblDoanhNghiep> TblDoanhNghieps { get; set; }
    }
}
