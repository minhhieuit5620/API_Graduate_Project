using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Model.Manager;

namespace IS.Model.DTO
{
    public class CauHoi_DTO
    {
        //public TblCauHoi Cau_Hoi { get; set; }
        //public TblLuaChon LuaChon { get; set; }



        //public partial class TblCauHoi
        //{
        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
    
        public string GoiYcauHoi { get; set; }
        public int? MaLoaiCauHoi { get; set; }
        public int? MaNhomCauHoi { get; set; }
        public string NguoiThem { get; set; }
        //select a.*, bool.name as name_b from a inner join b
        public DateTime? NgayThem { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }
        public int? TrangThai { get; set; }
        // Lựa chọn 
        public int MaLuaChon { get; set; }
        public int? MaCauHoi_LC { get; set; }
        public string NoiDung_LC { get; set; }
        public int? TrangThai_LC { get; set; }


        //}
        //public partial class TblLuaChon
        //{

        //    public int MaLuaChon { get; set; }
        //    public int? MaCauHoi { get; set; }
        //    public string NoiDung { get; set; }
        //    public int? TrangThai { get; set; }
        //}


    }
}
