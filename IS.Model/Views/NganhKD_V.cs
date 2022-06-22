using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class NganhKD_V:TblNganhKd
    {
    }   

    public class NganhKD_ReturnModel : ErrorMessage
    {
        public List<NganhKD_V> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class NganhKD_ModelParameter
    {
        public NganhKD_V Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
