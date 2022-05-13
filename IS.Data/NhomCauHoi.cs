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
    public class NhomCauHoi
    {
        private readonly ISSQLContext _context;

        public NhomCauHoi(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        #region Lấy dữ liệu
        public async Task<NhomCauHoiReturnModel> GetAllNhomCauHoi(NhomCauHoiModelParameter model)
        {
            IEnumerable<NhomCauHoiModel> resultModel;
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
            var result = await Task.FromResult(_context.CallToList<NhomCauHoiModel>("NhomCauHoi_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<NhomCauHoiModel>();
            var rs = new NhomCauHoiReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                rs.TotalRecord = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
            rs.Data = resultModel.ToList();
            return rs;
        }
        #endregion


        public async Task<NhomCauHoiModel> GetNhomCauHoiById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaNhomCauHoi", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<NhomCauHoiModel>("NhomCauHoi_GetByID", parameters));

            return result.Value;
        }




        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(TblNhomCauHoi model)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("ID_NhomCauHoi", DbType.Int32, model.MaNhomCauHoi),
                 _context.CreateInParameter("TenNhomCauHoi", DbType.String, model.TenNhomCauHoi),
                 _context.CreateInParameter("MaTieuChiCha", DbType.Int32, model.MaTieuChiCha),
                 _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                 _context.CreateInParameter("NguoiThem", DbType.String, model.NguoiThem),
                 _context.CreateInParameter("NguoiSua", DbType.String, model.NguoiSua),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("NhomCauHoi_Insert_OR_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion


        #region Xóa dữ liệu

        public async Task<int> DeleteNhomCauHoi(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaNhomCauHoi", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("NhomCauHoi_Delete", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion

    }
}
