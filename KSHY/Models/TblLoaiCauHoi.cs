using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblLoaiCauHoi
    {
        public TblLoaiCauHoi()
        {
            TblCauHois = new HashSet<TblCauHoi>();
        }

        public int MaLoaiCauHoi { get; set; }
        public string TenLoaiCauHoi { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? MaNguoiTao { get; set; }
        public int? MaNguoiSua { get; set; }
        public int? TrangThai { get; set; }

        public virtual ICollection<TblCauHoi> TblCauHois { get; set; }
    }
}
