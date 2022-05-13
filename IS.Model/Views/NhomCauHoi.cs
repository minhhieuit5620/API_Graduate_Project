using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Text;
namespace IS.Model.Views
{
    public class NhomCauHoiModel:TblNhomCauHoi
    {
        //public string Key { get; set; }
        //public string CountryCode { get; set; }
        //public string CountryName { get; set; }
        //public string ProvinceCode { get; set; }
       //public string ProvinceName { get; set; }
        //public string DistrictCode { get; set; }


       // public string DistrictName { get; set; }

        //public FillterParameter Filter { get; set; }
    }
    public class NhomCauHoiReturnModel : ErrorMessage
    {
        public List<NhomCauHoiModel> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class NhomCauHoiModelParameter
    {
        public NhomCauHoiModel Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
