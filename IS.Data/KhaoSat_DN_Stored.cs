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
    public class KhaoSat_DN_Stored
    {
        private readonly ISSQLContext _context;

        public KhaoSat_DN_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        #region Lấy dữ liệu
        public async Task<KhaoSat_DNReturnModel> GetDataKhaoSat_DN(KhaoSat_DNModelParameter model)
        {
            IEnumerable<KhaoSat_DN> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {

                _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
            };
            var result = await Task.FromResult(_context.CallToList<KhaoSat_DN>("GetdataKhaoSat", parameters));
            resultModel = result.Value ?? new List<KhaoSat_DN>();
            var rs = new KhaoSat_DNReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }
        #endregion

    }
}
