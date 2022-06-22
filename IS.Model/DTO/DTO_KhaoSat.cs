using IS.Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.DTO
{
    public class DTO_KhaoSat
    {
        public TblKhaoSat KhaoSat { get; set; }
        public TblChiTietKhaoSat[] ChiTietKhaoSat { get; set; }
      //  public TblTraLoiLuaChon TraLoiLuaChon { get; set; }
    }
}
