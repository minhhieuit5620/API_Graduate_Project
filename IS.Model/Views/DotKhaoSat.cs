using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class DotKhaoSat:TblDotKhaoSat
    {
    }
    public class DotKhaoSatReturnModel : ErrorMessage
    {
        public List<DotKhaoSat> Data { get; set; }
        public int TotalRecord { get; set; }
        public int pages { get; set; }
    }
    public class DotKhaoSatParameter
    {
        public DotKhaoSat Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
