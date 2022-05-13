using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblDotKhaoSat
    {
        public TblDotKhaoSat()
        {
            TblKhaoSats = new HashSet<TblKhaoSat>();
        }

        public int MaDotKhaoSat { get; set; }
        public string TenDotKhaoSat { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string FileBaoCaoKetQua { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string MaNguoitao { get; set; }
        public DateTime? NgaySua { get; set; }
        public string MaNguoiSua { get; set; }
        public string FileQuyetDinh { get; set; }
        public string FileKeHoach { get; set; }
        public int? TrangThai { get; set; }

        public virtual ICollection<TblKhaoSat> TblKhaoSats { get; set; }
    }
}
