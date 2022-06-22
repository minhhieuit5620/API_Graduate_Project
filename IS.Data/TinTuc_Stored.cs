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
    public class TinTuc_Stored
    {
        private readonly ISSQLContext _context;
      


        public TinTuc_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);

        }
        #region Lấy dữ liệu
        public async Task<TinTucReturnModel> GetAllTinTuc(TinTucModelParameter model)
        {
            IEnumerable<TinTucModel> resultModel;          
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
            var result = await Task.FromResult(_context.CallToList<TinTucModel>("TinTuc_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<TinTucModel>();
            var rs = new TinTucReturnModel();
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


        public async Task<TinTucModel> GetTinTucById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaTinTuc", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<TinTucModel>("TinTuc_GetByID", parameters));

            return result.Value;
        }

        public async Task<TinTucReturnModel> GetTinTucByMaLoai(int id)
        {
            List<TinTucModel> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaLoaiTin", DbType.Int32, id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<TinTucModel>("TinTucByMaLoai", parameters));
            resultModel = result.Value ?? new List<TinTucModel>();
            var rs = new TinTucReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }
        #region Thêm dữ liệu
        //public async Task<int> AddOrUpdate(TblTinTuc model)
        //{
        //    var parameters = new List<IDbDataParameter>
        //        {
        //            _context.CreateInParameter("ID_CauHoi", DbType.Int32, model.MaTinTuc),
        //            _context.CreateInParameter("NoiDung", DbType.String, model.Mota),           
        //        };

        //    var result = await Task.FromResult(_context.CallToValue("CH_CauHoi_Insert_Or_Update", parameters));

        //    return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        //}


        public async Task<int> AddOrUpdate(TblTinTuc model)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaTinTuc", DbType.Int32, model.MaTinTuc),
                      _context.CreateInParameter("MaLoaiTin", DbType.Int32, model.MaLoaiTin),
                 _context.CreateInParameter("TieuDe", DbType.String, model.TieuDe),
                  _context.CreateInParameter("Mota", DbType.String, model.Mota),
                   _context.CreateInParameter("HinhAnh", DbType.String, model.HinhAnh),                 
                 _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                 _context.CreateInParameter("NguoiThem", DbType.String, model.NguoiThem),
                 _context.CreateInParameter("NguoiSua", DbType.String, model.NguoiSua),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("TinTuc_Insert_Or_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion


        #region Xóa dữ liệu

        public async Task<int> DeleteTinTuc(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaTinTuc", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("TinTuc_Delete", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion
    }
}
