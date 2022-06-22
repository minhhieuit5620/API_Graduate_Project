using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class AddressProvincesRef
    {
        public AddressProvincesRef()
        {
            AddressDistrictsRefs = new HashSet<AddressDistrictsRef>();
        }

        public string MaTinh { get; set; }
        public string KiHieuTinh { get; set; }
        public string TenTinhE { get; set; }
        public string TenTinhL { get; set; }
        public int? KiHieuDienThoai { get; set; }
        public int? MaBuuChinh { get; set; }
        public string MaQuocGia { get; set; }
        public int? ThuTu { get; set; }
        public string GhiChuE { get; set; }
        public string GhiChuL { get; set; }
        public int TrangThai { get; set; }
        public Guid NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public Guid? NguoiSua { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string TuKhoa { get; set; }
        public string LoaiTinhE { get; set; }
        public string LoaiTinhL { get; set; }

        public virtual AddressCountriesRef MaQuocGiaNavigation { get; set; }
        public virtual ICollection<AddressDistrictsRef> AddressDistrictsRefs { get; set; }
    }
}
