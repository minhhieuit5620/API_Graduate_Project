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
    public class LoaiHinhDN_Stored
    {
        private readonly ISSQLContext _context;

        public LoaiHinhDN_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);

        }
        #region Lấy dữ liệu
        public async Task<LoaiHinhDN_ReturnModel> GetAllLoaiHinhDN(LoaiHinhDN_ModelParameter model)
        {
            IEnumerable<LoaiHinhDN_V> resultModel;
            var search = "";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                _context.CreateInParameter("IN_SEARCH_KEYWORD", DbType.String,search ),
                _context.CreateInParameter("IN_ACTIVE", DbType.Int32,model.Data.TrangThai),
                _context.CreateInParameter("IN_PAGE", DbType.Int32, model.Page?.PageIndex??Constant.DefaultPage.PageIndex),
                _context.CreateInParameter("IN_PAGE_SIZE", DbType.Int32, model.Page?.PageSize??Constant.DefaultPage.PageSize),
                _context.CreateOutParameter("OUT_TOTAL_ROW", DbType.Int32, 10),
                _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
            };
            var result = await Task.FromResult(_context.CallToList<LoaiHinhDN_V>("LoaiHinhDN_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<LoaiHinhDN_V>();
            var rs = new LoaiHinhDN_ReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                rs.TotalRecord = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
            rs.Data = resultModel.ToList();
            return rs;
        }
        #endregion
    }
}
