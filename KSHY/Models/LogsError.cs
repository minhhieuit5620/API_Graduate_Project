using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class LogsError
    {
        public Guid Id { get; set; }
        public Guid? MaNguoiDung { get; set; }
        public string HanhDong { get; set; }
        public string Controller { get; set; }
        public string ThongTinLoi { get; set; }
        public string DiaChiIp { get; set; }
        public string TrinhDuyet { get; set; }
        public string ThietBi { get; set; }
        public string Os { get; set; }
        public int TrangThai { get; set; }
        public Guid NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public Guid? NguoiSua { get; set; }
    }
}
