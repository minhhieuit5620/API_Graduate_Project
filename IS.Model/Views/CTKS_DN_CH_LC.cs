using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class CTKS_DN_CH_LC:TblCTKS_DN_CH_LC
    {
    }  
    public class CTKS_DN_CH_LCReturnModel : ErrorMessage
    {
        public List<CTKS_DN_CH_LC> Data { get; set; }
     
    }
    public class CTKS_DN_CH_LCModelParameter
    {
        public CTKS_DN_CH_LC Data { get; set; } 

    }
}
