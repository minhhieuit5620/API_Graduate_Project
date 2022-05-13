﻿using System;
using System.Collections.Generic;

#nullable disable

namespace KSHY.Models
{
    public partial class TblAdmin
    {
        public int Id { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int? Rol { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }

        public virtual TblPhanQuyen RolNavigation { get; set; }
    }
}
