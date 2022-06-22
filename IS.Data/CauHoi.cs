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

        //Câu hỏi

        public async Task<CauHoiReturnModel> GetCauHoiKhaoSat(CauHoiModelParameter model)
        {
            IEnumerable<CauHoiModel> resultModel;
            var search = "";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                _context.CreateInParameter("IN_SEARCH_KEYWORD", DbType.String,search ),
                _context.CreateInParameter("IN_ACTIVE", DbType.Int32,model.Data.TrangThai),
                _context.CreateInParameter("IN_PAGE", DbType.Int32, model.Page?.PageIndex??Constant.DefaultPage.PageIndex),
                _context.CreateInParameter("IN_PAGE_SIZE", DbType.Int32, 50),
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

        // Câu hỏi MN
        public async Task<CauHoiReturnModel> GetAllCauHoi(CauHoiModelParameter model)
        {
            IEnumerable<CauHoiModel> resultModel;         
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
            if (rs.TotalRecord % 10 > 0)
            {
                rs.pages = rs.TotalRecord / 10 + 1;
            }
            else
            {
                rs.pages = rs.TotalRecord / 10;
            }
            return rs;
        }

        public async Task<CauHoiReturnModel> SearchCauHoi(CauHoiModelParameter model,string search)
        {
            IEnumerable<CauHoiModel> resultModel;
            
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
            if (rs.TotalRecord % 10 > 0)
            {
                rs.pages = rs.TotalRecord / 10 + 1;
            }
            else
            {
                rs.pages = rs.TotalRecord / 10;
            }
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
        public async Task<int> AddOrUpdate(TblCauHoi model,List<TblLuaChon>  luachon)
        {
            if (model.MaLoaiCauHoi == 3)
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
            else
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

                for (int i = 0; i < luachon.Count; i++)
                {
                    var parametersLuaChon = new List<IDbDataParameter>
                    {
                        _context.CreateInParameter("MaLuaChon", DbType.Int32, luachon[i].MaLuaChon),
                     _context.CreateInParameter("MaCauHoi", DbType.Int32,luachon[i].MaCauHoi),
                     _context.CreateInParameter("NoiDung", DbType.String, luachon[i].NoiDung),
                     _context.CreateInParameter("TrangThai", DbType.Int32, luachon[i].TrangThai),
                        _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                        _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                          
                    };
                    var resultLC = await Task.FromResult(_context.CallToValue("CH_LuaChon_Insert_Or_Update", parametersLuaChon));
                    return resultLC.ErrorCode == 0 && string.IsNullOrEmpty(resultLC.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
                }            
                return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
            }
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
