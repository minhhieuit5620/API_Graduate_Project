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
    public class DotKhaoSat_Stored
    {

        private readonly ISSQLContext _context;

        public DotKhaoSat_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        #region Lấy dữ liệu
        public async Task<DotKhaoSatReturnModel> GetAllDotKhaoSat(DotKhaoSatParameter model)
        {
            IEnumerable<DotKhaoSat> resultModel;
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
            var result = await Task.FromResult(_context.CallToList<DotKhaoSat>("KS_DotKhaoSat_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<DotKhaoSat>();
            var rs = new DotKhaoSatReturnModel();
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

        public async Task<DotKhaoSatReturnModel> SearchDotKhaoSat(DotKhaoSatParameter model, string search)
        {
            IEnumerable<DotKhaoSat> resultModel;

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
            var result = await Task.FromResult(_context.CallToList<DotKhaoSat>("KS_DotKhaoSat_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<DotKhaoSat>();
            var rs = new DotKhaoSatReturnModel();
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


        public async Task<DotKhaoSat> GetDotKhaoSatById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDotKhaoSat", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<DotKhaoSat>("KS_DotKhaoSat_GetByID", parameters));

            return result.Value;
        }            
        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(DotKhaoSat model)
        {

            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDotKhaoSat", DbType.Int32, model.MaDotKhaoSat),                    
                  _context.CreateInParameter("TenDotKhaoSat", DbType.String, model.TenDotKhaoSat),
                    _context.CreateInParameter("MoTa", DbType.String, model.MoTa),
                    _context.CreateInParameter("NgayBatDau", DbType.Date, model.NgayBatDau),
                    _context.CreateInParameter("NgayKetThuc", DbType.Date, model.NgayKetThuc),
                    _context.CreateInParameter("FileBaoCaoKetQua", DbType.String, model.FileBaoCaoKetQua),
                    _context.CreateInParameter("MaNguoitao", DbType.Int32, model.MaNguoitao),
                    _context.CreateInParameter("MaNguoiSua", DbType.String, model.MaNguoiSua),
                    _context.CreateInParameter("FileQuyetDinh", DbType.String, model.FileQuyetDinh),
                    _context.CreateInParameter("FileKeHoach", DbType.String, model.FileKeHoach),
                _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                      _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("KS_DotKhaoSat_Insert_OR_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion
        #region Xóa dữ liệu

        public async Task<int> DeleteDotKhaoSat(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDotKhaoSat", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("KS_DotKhaoSat_DeleteById", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion

    }
}
