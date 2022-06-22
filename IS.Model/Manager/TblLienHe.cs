using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Manager
{
    public partial class TblLienHe
    {
        public int MaLienHe { get; set; }
        public string TenNguoiLienHe { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public int? MaDinhDanhDN { get; set; }
        public string TenDoanhNghiep { get; set; }
        public string NoiDungLH { get; set; }
        public DateTime? ThoiGianGui { get; set; }
        public DateTime? ThoiGianTraLoi { get; set; }
        public int? TrangThai { get; set; }
    }  
}
