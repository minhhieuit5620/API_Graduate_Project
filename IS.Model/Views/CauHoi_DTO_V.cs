using IS.Model.DTO;
using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
   // public class CauHoi
    public class CauHoi_DTO_V: CauHoi_DTO
    {
        //public TblCauHoi CauHois { get; set; }
        //public TblLuaChon LuaChons { get; set; }
    }   
    public class CauHoi_DTO_VReturnModel : ErrorMessage
    {
        public List<CauHoi_DTO_V> Data { get; set; }
       // public int TotalRecord { get; set; }
    }
    public class CauHoi_DTO_VModelParameter
    {
        public CauHoi_DTO_V Data { get; set; }
       // public PageParameter Page { get; set; }

    }
}
