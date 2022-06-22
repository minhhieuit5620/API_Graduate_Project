using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class AddressCountriesRef
    {
        public AddressCountriesRef()
        {
            AddressProvincesRefs = new HashSet<AddressProvincesRef>();
        }

        public string MaQuocGia { get; set; }
        public string KiHieu { get; set; }
        public string TenQuocGiaE { get; set; }
        public string TenQuocGiaL { get; set; }
        public string MaLoaiQuocGia { get; set; }
        public string ThuDo { get; set; }
        public string KiHieuTienTe { get; set; }
        public string TenTienTe { get; set; }
        public string KiHieuDienThoai { get; set; }
        public string KiHieuInternet { get; set; }
        public string Flags { get; set; }
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

        public virtual ICollection<AddressProvincesRef> AddressProvincesRefs { get; set; }
    }
}
