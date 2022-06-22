using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{  
    public class DoanhNghiep_V : TblDoanhNghieps
    {
     
    }
    public class DoanhNghiepReturnModel : ErrorMessage
    {
        public List<DoanhNghiep_V> Data { get; set; }
        public int TotalRecord { get; set; }
        public int pages { get; set; }
    }
    public class DoanhNghiepModelParameter
    {
        public DoanhNghiep_V Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
