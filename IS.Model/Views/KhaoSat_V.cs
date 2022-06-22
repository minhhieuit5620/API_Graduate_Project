using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class KhaoSat_V: TblKhaoSat
    {
    }
    public class KhaoSatReturnModel : ErrorMessage
    {
        public List<KhaoSat_V> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class KhaoSatModelParameter
    {
        public KhaoSat_V Data { get; set; }
        public PageParameter Page { get; set; }
    }

    //Chi tiết khảo sát
    public class CTKhaoSat_V : TblChiTietKhaoSat
    {
    }
    public class CTKhaoSatReturnModel : ErrorMessage
    {
        public List<CTKhaoSat_V> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class CTKhaoSatModelParameter
    {
        public CTKhaoSat_V Data { get; set; }
        public PageParameter Page { get; set; }
    }
}
