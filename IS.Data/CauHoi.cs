//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using IS.Model.Views;
using ISCommon.Constant;
using ISCommon.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KSHYDatabase;
using IS.Model.Manager;

namespace IS.Data
{
    public class CauHoi
    {

        private readonly ISSQLContext _context;

        public CauHoi(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        #region Lấy dữ liệu
        public async Task<CauHoiReturnModel> GetAllCauHoi(CauHoiModelParameter model)
        {
            IEnumerable<CauHoiModel> resultModel;
            //var advanceSearch = "";
            //if (model.Data.Filter != null && model.Data.Filter.filters != null)
            //{
            //    advanceSearch = LinqExpressions.ConvertFilterToString<NhomCauHoiModel>(model.Data.Filter.filters);
            //}
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
            var result = await Task.FromResult(_context.CallToList<CauHoiModel>("CH_CauHoi_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<CauHoiModel>();
            var rs = new CauHoiReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                rs.TotalRecord = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
            rs.Data = resultModel.ToList();
            return rs;
        }
        #endregion


        public async Task<CauHoiModel> GetCauHoiById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaCauHoi", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<CauHoiModel>("CH_CauHoi_GetByID", parameters));

            return result.Value;
        }

        public async Task<CauHoiReturnModel> GetCauHoiByMaNhom(int id)
        {
            List<CauHoiModel> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaNhomCauHoi", DbType.Int32, id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<CauHoiModel>("CH_GetCauHoi_KhaoSat", parameters));
            resultModel = result.Value ?? new List<CauHoiModel>();
            var rs = new CauHoiReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }




        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(TblCauHoi model)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("ID_CauHoi", DbType.Int32, model.MaCauHoi),
                 _context.CreateInParameter("NoiDung", DbType.String, model.NoiDung),
                 _context.CreateInParameter("GoiYCauHoi", DbType.String, model.GoiYcauHoi),
                 _context.CreateInParameter("MaLoaiCauHoi", DbType.Int32, model.MaLoaiCauHoi),
                 _context.CreateInParameter("MaNhomCauHoi", DbType.Int32, model.MaNhomCauHoi),
                     _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                 _context.CreateInParameter("NguoiThem", DbType.String, model.NguoiThem),
                 _context.CreateInParameter("NguoiSua", DbType.String, model.NguoiSua),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("CH_CauHoi_Insert_Or_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion


        #region Xóa dữ liệu

        public async Task<int> DeleteCauHoi(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaCauHoi", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("CH_CauHoi_Delete", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion
    }
}
