using IS.Model.Manager;
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
    public class LuaChon
    {
        private readonly ISSQLContext _context;

        public LuaChon(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        #region Lấy dữ liệu
        public async Task<LuaChonReturnModel> GetAllLuaChon(LuaChonModelParameter model)
        {
            IEnumerable<LuaChonModel> resultModel;
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
            var result = await Task.FromResult(_context.CallToList<LuaChonModel>("CH_LuaChon_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<LuaChonModel>();
            var rs = new LuaChonReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                rs.TotalRecord = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
            rs.Data = resultModel.ToList();
            return rs;
        }
        #endregion


        public async Task<LuaChonModel> GetLuaChonById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaCauHoi", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<LuaChonModel>("CH_CauHoi_GetByID", parameters));

            return result.Value;
        }

        public async Task<LuaChonReturnModel> GetLuaChonByMaCauHoi(int id)
        {
            List<LuaChonModel> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaCauHoi", DbType.Int32, id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<LuaChonModel>("CH_LuaChonCauHoi", parameters));
            resultModel = result.Value ?? new List<LuaChonModel>();
            var rs = new LuaChonReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }




        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(TblLuaChon model)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("ID_CauHoi", DbType.Int32, model.MaCauHoi),
                 _context.CreateInParameter("NoiDung", DbType.String, model.NoiDung),
                 //_context.CreateInParameter("GoiYCauHoi", DbType.String, model.GoiYcauHoi),
                 //_context.CreateInParameter("MaLoaiCauHoi", DbType.Int32, model.MaLoaiCauHoi),
                 //_context.CreateInParameter("MaNhomCauHoi", DbType.Int32, model.MaNhomCauHoi),
                 //    _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                 //_context.CreateInParameter("NguoiThem", DbType.String, model.NguoiThem),
                 //_context.CreateInParameter("NguoiSua", DbType.String, model.NguoiSua),
                 //   _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                 //   _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("CH_CauHoi_Insert_Or_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion


        #region Xóa dữ liệu

        public async Task<int> DeleteLuaChonByMaCauHoi(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaCauHoi", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("CH_DeleteLuaChon_byMaCauHoi", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion
    }
}
