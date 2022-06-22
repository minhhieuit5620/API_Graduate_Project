using IS.Model.Views;
using ISCommon.Constant;
using KSHYDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Data
{
    public class CauHoiDTO
    {
        private readonly ISSQLContext _context;

        public CauHoiDTO(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        public async Task<CauHoi_DTO_VReturnModel> GetAllCauHoi_LuaChon_DTO(CauHoi_DTO_VModelParameter model)
        {
            IEnumerable<CauHoi_DTO_V> resultModel;              
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                
                _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
            };
            var result = await Task.FromResult(_context.CallToList<CauHoi_DTO_V>("CH_CauHoi_DapAn_All", parameters));
            resultModel = result.Value ?? new List<CauHoi_DTO_V>();
            var rs = new CauHoi_DTO_VReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;        
            rs.Data = resultModel.ToList();
            return rs;
        }

        public async Task<CauHoi_DTO_VReturnModel> GetCauHoi_LuaChonById(int Id)
        {
            IEnumerable<CauHoi_DTO_V> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaCauHoi", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<CauHoi_DTO_V>("CH_CauHoi_DapAn_ByMaCauHoi", parameters));
            resultModel = result.Value ?? new List<CauHoi_DTO_V>();
            var rs = new CauHoi_DTO_VReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            //if (result.Output["OUT_TOTAL_ROW"] + "" != "")
            //    rs.TotalRecord = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
            rs.Data = resultModel.ToList();
            return rs;
        }
    }
}
