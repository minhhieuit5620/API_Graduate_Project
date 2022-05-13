using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KSHY.Models
{
    public partial class KHAOSATHYContext : DbContext
    {
        public KHAOSATHYContext()
        {
        }

        public KHAOSATHYContext(DbContextOptions<KHAOSATHYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressCountriesRef> AddressCountriesRefs { get; set; }
        public virtual DbSet<AddressDistrictsRef> AddressDistrictsRefs { get; set; }
        public virtual DbSet<AddressProvincesRef> AddressProvincesRefs { get; set; }
        public virtual DbSet<AddressWardsRef> AddressWardsRefs { get; set; }
        public virtual DbSet<LogsAction> LogsActions { get; set; }
        public virtual DbSet<LogsError> LogsErrors { get; set; }
        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblCauHoi> TblCauHois { get; set; }
        public virtual DbSet<TblChiTietKhaoSat> TblChiTietKhaoSats { get; set; }
        public virtual DbSet<TblDoanhNghiep> TblDoanhNghieps { get; set; }
        public virtual DbSet<TblDotKhaoSat> TblDotKhaoSats { get; set; }
        public virtual DbSet<TblKhaoSat> TblKhaoSats { get; set; }
        public virtual DbSet<TblLoaiCauHoi> TblLoaiCauHois { get; set; }
        public virtual DbSet<TblLoaiHinhDn> TblLoaiHinhDns { get; set; }
        public virtual DbSet<TblLuaChon> TblLuaChons { get; set; }
        public virtual DbSet<TblNganhKd> TblNganhKds { get; set; }
        public virtual DbSet<TblNhomCauHoi> TblNhomCauHois { get; set; }
        public virtual DbSet<TblPhanQuyen> TblPhanQuyens { get; set; }
        public virtual DbSet<TblTaiKhoanDn> TblTaiKhoanDns { get; set; }
        public virtual DbSet<TblTinTuc> TblTinTucs { get; set; }
        public virtual DbSet<TblTinTucLoai> TblTinTucLoais { get; set; }
        public virtual DbSet<TblTraLoiLuaChon> TblTraLoiLuaChons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=103.101.162.107;Database=KHAOSATHY;UID=SA;PWD=U2kqZuK0syuLN4B6");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AddressCountriesRef>(entity =>
            {
                entity.HasKey(e => e.MaQuocGia)
                    .HasName("PK_m_countries");

                entity.ToTable("Address_countries_ref");

                entity.Property(e => e.MaQuocGia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Flags)
                    .HasMaxLength(350)
                    .HasColumnName("flags");

                entity.Property(e => e.GhiChuE)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_E")
                    .HasComment("Ghi chú");

                entity.Property(e => e.GhiChuL)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_L")
                    .HasComment("Ghi chú");

                entity.Property(e => e.KiHieu)
                    .HasMaxLength(36)
                    .HasComment("MÃ QUỐC GIA");

                entity.Property(e => e.KiHieuDienThoai).HasMaxLength(10);

                entity.Property(e => e.KiHieuInternet).HasMaxLength(10);

                entity.Property(e => e.KiHieuTienTe).HasMaxLength(10);

                entity.Property(e => e.MaLoaiQuocGia).HasMaxLength(50);

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TenQuocGiaE)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenQuocGia_E")
                    .HasDefaultValueSql("('')")
                    .HasComment("TÊN QUỐC GIA");

                entity.Property(e => e.TenQuocGiaL)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenQuocGia_L")
                    .HasDefaultValueSql("('')")
                    .HasComment("TÊN QUỐC GIA");

                entity.Property(e => e.TenTienTe).HasMaxLength(10);

                entity.Property(e => e.ThuDo).HasMaxLength(50);

                entity.Property(e => e.ThuTu)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Thứ tự sắp xếp");

                entity.Property(e => e.TieuDe).HasMaxLength(250);

                entity.Property(e => e.TrangThai).HasComment("Trạng thái (0: inactive, 1: Active, -1: Xóa)");

                entity.Property(e => e.TuKhoa).HasMaxLength(250);
            });

            modelBuilder.Entity<AddressDistrictsRef>(entity =>
            {
                entity.HasKey(e => e.MaQuanHuyen)
                    .HasName("PK_m_districts");

                entity.ToTable("Address_districts_ref");

                entity.Property(e => e.MaQuanHuyen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChuE)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_E");

                entity.Property(e => e.GhiChuL)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_L");

                entity.Property(e => e.KiHieuQuanHuyen)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.KinhDoViDo).HasMaxLength(50);

                entity.Property(e => e.LoaiQuanHuyenE)
                    .HasMaxLength(20)
                    .HasColumnName("LoaiQuanHuyen_E");

                entity.Property(e => e.LoaiQuanHuyenL)
                    .HasMaxLength(20)
                    .HasColumnName("LoaiQuanHuyen_L");

                entity.Property(e => e.MaTinh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TenQuanHuyenE)
                    .HasMaxLength(100)
                    .HasColumnName("TenQuanHuyen_E");

                entity.Property(e => e.TenQuanHuyenL)
                    .HasMaxLength(100)
                    .HasColumnName("TenQuanHuyen_L");

                entity.Property(e => e.TieuDe).HasMaxLength(250);

                entity.Property(e => e.TuKhoa).HasMaxLength(250);

                entity.HasOne(d => d.MaTinhNavigation)
                    .WithMany(p => p.AddressDistrictsRefs)
                    .HasForeignKey(d => d.MaTinh)
                    .HasConstraintName("FK_Address_districts_ref_Address_provinces_ref");
            });

            modelBuilder.Entity<AddressProvincesRef>(entity =>
            {
                entity.HasKey(e => e.MaTinh)
                    .HasName("PK_m_provinces");

                entity.ToTable("Address_provinces_ref");

                entity.Property(e => e.MaTinh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChuE)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_E")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Ghi chú");

                entity.Property(e => e.GhiChuL)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_L")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Ghi chú");

                entity.Property(e => e.KiHieuTinh)
                    .HasMaxLength(36)
                    .HasComment("MÃ TỈNH THÀNH");

                entity.Property(e => e.LoaiTinhE)
                    .HasMaxLength(50)
                    .HasColumnName("LoaiTinh_E");

                entity.Property(e => e.LoaiTinhL)
                    .HasMaxLength(50)
                    .HasColumnName("LoaiTinh_L");

                entity.Property(e => e.MaQuocGia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Mã quốc gia (M_COUNTRIES.Id)");

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TenTinhE)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenTinh_E")
                    .HasDefaultValueSql("('')")
                    .HasComment("TÊN TỈNH THÀNH");

                entity.Property(e => e.TenTinhL)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenTinh_L")
                    .HasDefaultValueSql("('')")
                    .HasComment("TÊN TỈNH THÀNH");

                entity.Property(e => e.ThuTu).HasComment("Thứ tự sắp xếp");

                entity.Property(e => e.TieuDe).HasMaxLength(250);

                entity.Property(e => e.TrangThai).HasComment("Trạng thái (0: inactive, 1: Active, -1: Xóa)");

                entity.Property(e => e.TuKhoa).HasMaxLength(250);

                entity.HasOne(d => d.MaQuocGiaNavigation)
                    .WithMany(p => p.AddressProvincesRefs)
                    .HasForeignKey(d => d.MaQuocGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_provinces_ref_Address_countries_ref");
            });

            modelBuilder.Entity<AddressWardsRef>(entity =>
            {
                entity.HasKey(e => e.MaPhuongXa)
                    .HasName("PK_m_wards");

                entity.ToTable("Address_wards_ref");

                entity.Property(e => e.MaPhuongXa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChuE)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_E");

                entity.Property(e => e.GhiChuL)
                    .HasMaxLength(250)
                    .HasColumnName("GhiChu_L");

                entity.Property(e => e.KiHieuPhuongXa)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.KinhDoViDo).HasMaxLength(50);

                entity.Property(e => e.LoaiPhuongXaE)
                    .HasMaxLength(50)
                    .HasColumnName("LoaiPhuongXa_E");

                entity.Property(e => e.LoaiPhuongXaL)
                    .HasMaxLength(50)
                    .HasColumnName("LoaiPhuongXa_L");

                entity.Property(e => e.MaQuanHuyen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TenPhuongXaE)
                    .HasMaxLength(100)
                    .HasColumnName("TenPhuongXa_E");

                entity.Property(e => e.TenPhuongXaL)
                    .HasMaxLength(100)
                    .HasColumnName("TenPhuongXa_L");

                entity.Property(e => e.TieuDe).HasMaxLength(250);

                entity.Property(e => e.TuKhoa).HasMaxLength(250);

                entity.HasOne(d => d.MaQuanHuyenNavigation)
                    .WithMany(p => p.AddressWardsRefs)
                    .HasForeignKey(d => d.MaQuanHuyen)
                    .HasConstraintName("FK_Address_wards_ref_Address_districts_ref");
            });

            modelBuilder.Entity<LogsAction>(entity =>
            {
                entity.ToTable("logs_action");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DiaChiIp)
                    .HasMaxLength(15)
                    .HasColumnName("DiaChiIP");

                entity.Property(e => e.EffectedData)
                    .HasMaxLength(250)
                    .HasColumnName("effected_data");

                entity.Property(e => e.HanhDong).HasMaxLength(150);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Os)
                    .HasMaxLength(100)
                    .HasColumnName("os");

                entity.Property(e => e.TenBang).HasMaxLength(150);

                entity.Property(e => e.TenTruong).HasMaxLength(150);

                entity.Property(e => e.ThietBi).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasComment("Trạng thái (0: inactive, 1: Active, -1: Xóa)");

                entity.Property(e => e.TrinhDuyet).HasMaxLength(150);
            });

            modelBuilder.Entity<LogsError>(entity =>
            {
                entity.ToTable("logs_error");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Controller).HasMaxLength(150);

                entity.Property(e => e.DiaChiIp)
                    .HasMaxLength(15)
                    .HasColumnName("DiaChiIP");

                entity.Property(e => e.HanhDong).HasMaxLength(150);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Os)
                    .HasMaxLength(100)
                    .HasColumnName("os");

                entity.Property(e => e.ThietBi).HasMaxLength(50);

                entity.Property(e => e.ThongTinLoi)
                    .HasMaxLength(500)
                    .HasComment("Lỗi");

                entity.Property(e => e.TrangThai).HasComment("Trạng thái (0: inactive, 1: Active, -1: Xóa)");

                entity.Property(e => e.TrinhDuyet).HasMaxLength(150);
            });

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.ToTable("tblAdmin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoVaTen).HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiSua).HasMaxLength(250);

                entity.Property(e => e.NguoiTao).HasMaxLength(250);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.TblAdmins)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_tblAdmin_tblPhanQuyen");
            });

            modelBuilder.Entity<TblCauHoi>(entity =>
            {
                entity.HasKey(e => e.MaCauHoi);

                entity.ToTable("tblCauHoi");

                entity.Property(e => e.GoiYcauHoi).HasColumnName("GoiYCauHoi");

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayThem).HasColumnType("datetime");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiThem).HasMaxLength(100);

                entity.HasOne(d => d.MaLoaiCauHoiNavigation)
                    .WithMany(p => p.TblCauHois)
                    .HasForeignKey(d => d.MaLoaiCauHoi)
                    .HasConstraintName("FK_tblCauHoi_tblLoaiCauHoi");

                entity.HasOne(d => d.MaNhomCauHoiNavigation)
                    .WithMany(p => p.TblCauHois)
                    .HasForeignKey(d => d.MaNhomCauHoi)
                    .HasConstraintName("FK_tblCauHoi_tblNhomCauHoi");
            });

            modelBuilder.Entity<TblChiTietKhaoSat>(entity =>
            {
                entity.HasKey(e => e.MaChiTietKhaoSat);

                entity.ToTable("tblChiTietKhaoSat");

                entity.Property(e => e.MaChiTietKhaoSat).ValueGeneratedNever();

                entity.Property(e => e.GiaTriNhap).HasMaxLength(250);

                entity.Property(e => e.ThoiGianTraLoi).HasColumnType("date");

                entity.HasOne(d => d.MaCauHoiNavigation)
                    .WithMany(p => p.TblChiTietKhaoSats)
                    .HasForeignKey(d => d.MaCauHoi)
                    .HasConstraintName("FK_tblChiTietKhaoSat_tblCauHoi");

                entity.HasOne(d => d.MaKhaoSatNavigation)
                    .WithMany(p => p.TblChiTietKhaoSats)
                    .HasForeignKey(d => d.MaKhaoSat)
                    .HasConstraintName("FK_tblChiTietKhaoSat_tblKhaoSat");
            });

            modelBuilder.Entity<TblDoanhNghiep>(entity =>
            {
                entity.HasKey(e => e.MaDoanhNghiep)
                    .HasName("PK_DoanhNghiep");

                entity.ToTable("tblDoanhNghiep");

                entity.Property(e => e.MaDoanhNghiep).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.DienThoai).HasMaxLength(20);

                entity.Property(e => e.DistrictsRcd).HasColumnName("districts_rcd");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiDungDau).HasMaxLength(100);

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiTao).HasMaxLength(100);

                entity.Property(e => e.ProvincesRcd).HasColumnName("provinces_rcd");

                entity.Property(e => e.QuyMo).HasMaxLength(50);

                entity.Property(e => e.TenToChuc).HasMaxLength(250);

                entity.Property(e => e.TieuDe).HasMaxLength(100);

                entity.Property(e => e.TinhThanh).HasMaxLength(250);

                entity.Property(e => e.WardsRcd).HasColumnName("wards_rcd");

                entity.Property(e => e.Website).HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiHinhNavigation)
                    .WithMany(p => p.TblDoanhNghieps)
                    .HasForeignKey(d => d.MaLoaiHinh)
                    .HasConstraintName("FK_tblDoanhNghiep_tblLoaiHinhDN");

                entity.HasOne(d => d.MaNganhNavigation)
                    .WithMany(p => p.TblDoanhNghieps)
                    .HasForeignKey(d => d.MaNganh)
                    .HasConstraintName("FK_tblDoanhNghiep_tblNganhKD");
            });

            modelBuilder.Entity<TblDotKhaoSat>(entity =>
            {
                entity.HasKey(e => e.MaDotKhaoSat);

                entity.ToTable("tblDotKhaoSat");

                entity.Property(e => e.MaDotKhaoSat).ValueGeneratedNever();

                entity.Property(e => e.FileBaoCaoKetQua)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileKeHoach)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileQuyetDinh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaNguoiSua)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaNguoitao)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.NgaySua).HasColumnType("date");

                entity.Property(e => e.Ngaytao).HasColumnType("date");

                entity.Property(e => e.TenDotKhaoSat).HasMaxLength(250);
            });

            modelBuilder.Entity<TblKhaoSat>(entity =>
            {
                entity.HasKey(e => e.MaKhaoSat)
                    .HasName("PK_tblDanhGia");

                entity.ToTable("tblKhaoSat");

                entity.Property(e => e.NgayDanhGia).HasColumnType("datetime");

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NguoiDanhGia).HasMaxLength(100);

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.HasOne(d => d.MaDoanhNghiepNavigation)
                    .WithMany(p => p.TblKhaoSats)
                    .HasForeignKey(d => d.MaDoanhNghiep)
                    .HasConstraintName("FK_tblKhaoSat_tblDoanhNghiep");

                entity.HasOne(d => d.MaDotKhaoSatNavigation)
                    .WithMany(p => p.TblKhaoSats)
                    .HasForeignKey(d => d.MaDotKhaoSat)
                    .HasConstraintName("FK_tblKhaoSat_tblDotKhaoSat");
            });

            modelBuilder.Entity<TblLoaiCauHoi>(entity =>
            {
                entity.HasKey(e => e.MaLoaiCauHoi);

                entity.ToTable("tblLoaiCauHoi");

                entity.Property(e => e.MaLoaiCauHoi).ValueGeneratedNever();

                entity.Property(e => e.MoTa).HasMaxLength(250);

                entity.Property(e => e.NgaySua).HasColumnType("date");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.TenLoaiCauHoi).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLoaiHinhDn>(entity =>
            {
                entity.HasKey(e => e.MaLoaiHinh)
                    .HasName("PK_LoaiHinhDN");

                entity.ToTable("tblLoaiHinhDN");

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayThem).HasColumnType("datetime");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiThem).HasMaxLength(100);

                entity.Property(e => e.TenLoaiHinh).HasMaxLength(250);
            });

            modelBuilder.Entity<TblLuaChon>(entity =>
            {
                entity.HasKey(e => e.MaLuaChon);

                entity.ToTable("tblLuaChon");

                entity.Property(e => e.NoiDung).HasMaxLength(50);

                entity.HasOne(d => d.MaCauHoiNavigation)
                    .WithMany(p => p.TblLuaChons)
                    .HasForeignKey(d => d.MaCauHoi)
                    .HasConstraintName("FK_tblLuaChon_tblCauHoi");
            });

            modelBuilder.Entity<TblNganhKd>(entity =>
            {
                entity.HasKey(e => e.MaNganh)
                    .HasName("PK_NganhKD");

                entity.ToTable("tblNganhKD");

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayThem).HasColumnType("datetime");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiThem).HasMaxLength(100);

                entity.Property(e => e.TenNganh).HasMaxLength(250);
            });

            modelBuilder.Entity<TblNhomCauHoi>(entity =>
            {
                entity.HasKey(e => e.MaNhomCauHoi)
                    .HasName("PK_tblTieuChiDanhGia");

                entity.ToTable("tblNhomCauHoi");

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayThem).HasColumnType("datetime");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiThem).HasMaxLength(100);

                entity.Property(e => e.TenNhomCauHoi).HasMaxLength(250);
            });

            modelBuilder.Entity<TblPhanQuyen>(entity =>
            {
                entity.HasKey(e => e.MaQuyen);

                entity.ToTable("tblPhanQuyen");

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.NgaySua).HasColumnType("date");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.NguoiSua).HasMaxLength(50);

                entity.Property(e => e.NguoiTao).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTaiKhoanDn>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoan);

                entity.ToTable("tblTaiKhoanDN");

                entity.Property(e => e.MatKhau).HasMaxLength(100);

                entity.Property(e => e.NgaySua).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiTao).HasMaxLength(100);

                entity.Property(e => e.TaiKhoan).HasMaxLength(30);

                entity.HasOne(d => d.MaToChucNavigation)
                    .WithMany(p => p.TblTaiKhoanDns)
                    .HasForeignKey(d => d.MaToChuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTaiKhoanDN_tblDoanhNghiep");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.TblTaiKhoanDns)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_tblTaiKhoanDN_tblPhanQuyen");
            });

            modelBuilder.Entity<TblTinTuc>(entity =>
            {
                entity.HasKey(e => e.MaTinTuc);

                entity.ToTable("tblTinTuc");

                entity.Property(e => e.NgaySua).HasColumnType("date");

                entity.Property(e => e.NgayThem).HasColumnType("date");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiThem).HasMaxLength(100);

                entity.Property(e => e.TieuDe).HasMaxLength(100);
            });

            modelBuilder.Entity<TblTinTucLoai>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTinTuc);

                entity.ToTable("tblTinTucLoai");

                entity.Property(e => e.NgaySua).HasColumnType("date");

                entity.Property(e => e.NgayThem).HasColumnType("date");

                entity.Property(e => e.NguoiSua).HasMaxLength(100);

                entity.Property(e => e.NguoiThem).HasMaxLength(100);
            });

            modelBuilder.Entity<TblTraLoiLuaChon>(entity =>
            {
                entity.HasKey(e => e.MaTraLoiDaLuaChon)
                    .HasName("PK_tblTraLoiDaLuaChon");

                entity.ToTable("tblTraLoiLuaChon");

                entity.Property(e => e.MaTraLoiDaLuaChon).ValueGeneratedNever();

                entity.HasOne(d => d.MaChiTietKhaoSatNavigation)
                    .WithMany(p => p.TblTraLoiLuaChons)
                    .HasForeignKey(d => d.MaChiTietKhaoSat)
                    .HasConstraintName("FK_tblTraLoiLuaChon_tblChiTietKhaoSat");

                entity.HasOne(d => d.MaLuaChonNavigation)
                    .WithMany(p => p.TblTraLoiLuaChons)
                    .HasForeignKey(d => d.MaLuaChon)
                    .HasConstraintName("FK_tblTraLoiLuaChon_tblLuaChon");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
