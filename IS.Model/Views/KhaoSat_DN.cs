using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class KhaoSat_DN:TblKhaoSat_DN
    {
    }
    
    public class KhaoSat_DNReturnModel : ErrorMessage
    {
        public List<KhaoSat_DN> Data { get; set; } 
    }
    public class KhaoSat_DNModelParameter
    {
        public KhaoSat_DN Data { get; set; }     

    }
}
