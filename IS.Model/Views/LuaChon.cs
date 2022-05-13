using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace IS.Model.Views
{
    public  class LuaChonModel:TblLuaChon
    {

    }
    public class LuaChonReturnModel : ErrorMessage
    {
        public List<LuaChonModel> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class LuaChonModelParameter
    {
        public LuaChonModel Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
