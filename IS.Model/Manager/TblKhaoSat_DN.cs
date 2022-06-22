using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Manager
{
    public partial class TblKhaoSat_DN
    {
        public int MaDoanhNghiep { get; set; }
        public int? MaDinhDanhDn { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenToChuc { get; set; }
        public string DiaChi { get; set; }
        public string TinhThanh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string NguoiKhaoSat { get; set; }
        public int? MaNganh { get; set; }
        public int? MaLoaiHinh { get; set; }
        public string QuyMo { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public int? TrangThai { get; set; }
        public int? Rol { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }


        public int MaDotKhaoSat_dks { get; set; }
        public string TenDotKhaoSat_dks { get; set; }
        public string MoTa_dks { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string FileBaoCaoKetQua { get; set; }
        public DateTime? Ngaytao_dks { get; set; }
        public int MaNguoitao { get; set; }
        public DateTime? NgaySua_dks { get; set; }
        public int MaNguoiSua { get; set; }
        public string FileQuyetDinh { get; set; }
        public string FileKeHoach { get; set; }
        public int? TrangThai_dks { get; set; }

        public int MaKhaoSat { get; set; }
        public int? MaDoanhNghiep_ks { get; set; }
        public DateTime? NgayDanhGia { get; set; }
        public DateTime? NgaySua_ks  { get; set; }
        public string NguoiSua_ks { get; set; }
        public int? MaDotKhaoSat { get; set; }
        public int? TrangThai_ks { get; set; }
    }
}
