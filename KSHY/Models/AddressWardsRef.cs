using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class AddressWardsRef
    {
        public string MaPhuongXa { get; set; }
        public string KiHieuPhuongXa { get; set; }
        public string TenPhuongXaE { get; set; }
        public string TenPhuongXaL { get; set; }
        public string LoaiPhuongXaE { get; set; }
        public string LoaiPhuongXaL { get; set; }
        public string KinhDoViDo { get; set; }
        public string MaQuanHuyen { get; set; }
        public int? ThuTu { get; set; }
        public string GhiChuE { get; set; }
        public string GhiChuL { get; set; }
        public int? TrangThai { get; set; }
        public Guid NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public Guid? NguoiSua { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string TuKhoa { get; set; }

        public virtual AddressDistrictsRef MaQuanHuyenNavigation { get; set; }
    }
}
