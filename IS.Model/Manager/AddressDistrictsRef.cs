using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class AddressDistrictsRef
    {
        public AddressDistrictsRef()
        {
            AddressWardsRefs = new HashSet<AddressWardsRef>();
        }

        public string MaQuanHuyen { get; set; }
        public string KiHieuQuanHuyen { get; set; }
        public string TenQuanHuyenE { get; set; }
        public string TenQuanHuyenL { get; set; }
        public string LoaiQuanHuyenE { get; set; }
        public string LoaiQuanHuyenL { get; set; }
        public string KinhDoViDo { get; set; }
        public string MaTinh { get; set; }
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

        public virtual AddressProvincesRef MaTinhNavigation { get; set; }
        public virtual ICollection<AddressWardsRef> AddressWardsRefs { get; set; }
    }
}
