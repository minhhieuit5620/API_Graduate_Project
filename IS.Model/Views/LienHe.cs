using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class LienHe:TblLienHe
    {
    }
    public class LienHeReturnModel : ErrorMessage
    {
        public List<LienHe> Data { get; set; }
        public int TotalRecord { get; set; }
        public int pages { get; set; }
    }
    public class LienHeParameter
    {
        public LienHe Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
