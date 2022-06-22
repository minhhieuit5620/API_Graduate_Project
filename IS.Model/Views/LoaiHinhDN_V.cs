using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class LoaiHinhDN_V:TblLoaiHinhDn
    {

    }

    public class LoaiHinhDN_ReturnModel : ErrorMessage
    {
        public List<LoaiHinhDN_V> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class LoaiHinhDN_ModelParameter
    {
        public LoaiHinhDN_V Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
