using IS.Model.Views;
using KSHYDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Data
{
    public class CTKS_DN_CH_LC_Stored
    {
        private readonly ISSQLContext _context;

        public CTKS_DN_CH_LC_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }

        public async Task<CTKS_DN_CH_LC> GetCTKSById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaKhaoSat", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<CTKS_DN_CH_LC>("GetDataCT_KhaoSat", parameters));

            return result.Value;
        }


        public async Task<CTKS_DN_CH_LCReturnModel> GetLuaChonByMaCauHoi(int id)
        {
            List<CTKS_DN_CH_LC> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaKhaoSat", DbType.Int32, id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<CTKS_DN_CH_LC>("GetDataCT_KhaoSat", parameters));
            resultModel = result.Value ?? new List<CTKS_DN_CH_LC>();
            var rs = new CTKS_DN_CH_LCReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }
        public async Task<CTKS_DN_CH_LCReturnModel> GetAllKS()
        {
            List<CTKS_DN_CH_LC> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {                  
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<CTKS_DN_CH_LC>("GetdataKhaoSat", parameters));
            resultModel = result.Value ?? new List<CTKS_DN_CH_LC>();
            var rs = new CTKS_DN_CH_LCReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }
        //public async Task<CTKS_DN_CH_LCReturnModel> GetAllKS(CTKS_DN_CH_LCModelParameter model)
        //{
        //    IEnumerable<CTKS_DN_CH_LC> resultModel;          
        //    List<IDbDataParameter> parameters = new List<IDbDataParameter>
        //        {               
        //        _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
        //        _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
        //    };
        //    var result = await Task.FromResult(_context.CallToList<CTKS_DN_CH_LC>("GetdataKhaoSat", parameters));
        //    resultModel = result.Value ?? new List<CTKS_DN_CH_LC>();
        //    var rs = new CTKS_DN_CH_LCReturnModel();
        //    rs.err_cd = result.ErrorCode;
        //    rs.err_msg = result.ErrorMessage;
        //    if (result.Output["OUT_TOTAL_ROW"] + "" != "")
        //        rs.TotalRecord = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
        //    rs.Data = resultModel.ToList();
        //    if (rs.TotalRecord % 10 > 0)
        //    {
        //        rs.pages = rs.TotalRecord / 10 + 1;
        //    }
        //    else
        //    {
        //        rs.pages = rs.TotalRecord / 10;
        //    }
        //    return rs;
        //}



    }
}
