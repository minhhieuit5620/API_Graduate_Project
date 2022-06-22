using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class TinTucModel:TblTinTuc
    {
    }
    public class TinTucReturnModel : ErrorMessage
    {
        public List<TinTucModel> Data { get; set; }
        public int TotalRecord { get; set; }
        public int pages { get; set; }
    }
    public class TinTucModelParameter
    {
        public TinTucModel Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
