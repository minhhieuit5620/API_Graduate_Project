using System;
using System.Collections.Generic;

#nullable disable

namespace IS.Model.Manager
{
    public partial class TblDotKhaoSat
    {
     

        public int MaDotKhaoSat { get; set; }
        public string TenDotKhaoSat { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string FileBaoCaoKetQua { get; set; }
        public DateTime? Ngaytao { get; set; }
        public int MaNguoitao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int MaNguoiSua { get; set; }
        public string FileQuyetDinh { get; set; }
        public string FileKeHoach { get; set; }
        public int? TrangThai { get; set; }

     
    }
}
