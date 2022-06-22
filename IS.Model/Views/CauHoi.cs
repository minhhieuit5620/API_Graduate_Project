using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Model.Views
{
    public class CauHoiModel:TblCauHoi
    {
    }
    public class CauHoiReturnModel : ErrorMessage
    {
        public List<CauHoiModel> Data { get; set; }
        public int TotalRecord { get; set; }
        public int pages { get; set; }
    }
    public class CauHoiModelParameter
    {
        public CauHoiModel Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
