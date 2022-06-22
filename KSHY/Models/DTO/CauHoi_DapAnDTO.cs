using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSHY.Models.DTO
{
    public class CauHoi_DapAnDTO
    {
        public TblCauHoi CauHoi { get; set; }
        public TblLuaChon[] LuaChon { get; set; }
    }
}
