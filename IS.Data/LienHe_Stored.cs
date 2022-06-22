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
   public class LienHe_Stored
    {

        private readonly ISSQLContext _context;

        public LienHe_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }
        #region
        public async Task<LienHeReturnModel> GetAllLienHe(LienHeParameter model)
        {
            IEnumerable<LienHe> resultModel;

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
            var result = await Task.FromResult(_context.CallToList<LienHe>("LienHe_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<LienHe>();
            var rs = new LienHeReturnModel();
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


        public async Task<LienHeReturnModel> SearchLienHe(LienHeParameter model, string search)
        {
            IEnumerable<LienHe> resultModel;
            var tmp = "";

            if (search == null)
            {
                tmp = search;

            }
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {

                _context.CreateInParameter("IN_SEARCH_KEYWORD", DbType.String,tmp ),
                _context.CreateInParameter("IN_ACTIVE", DbType.Int32,model.Data.TrangThai),
                _context.CreateInParameter("IN_PAGE", DbType.Int32, model.Page?.PageIndex??Constant.DefaultPage.PageIndex),
                _context.CreateInParameter("IN_PAGE_SIZE", DbType.Int32, model.Page?.PageSize??Constant.DefaultPage.PageSize),
                _context.CreateOutParameter("OUT_TOTAL_ROW", DbType.Int32, 10),
                _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
            };
            var result = await Task.FromResult(_context.CallToList<LienHe>("LienHe_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<LienHe>();
            var rs = new LienHeReturnModel();
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


        public async Task<LienHe> GetLienHeById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {

                    _context.CreateInParameter("MaLienHe", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToFirstOrDefault<LienHe>("LienHe_GetByID", parameters));

            return result.Value;
        }




        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(TblLienHe model)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaLienHe", DbType.Int32, model.MaLienHe),
                 _context.CreateInParameter("TenNguoiLienHe", DbType.String, model.TenNguoiLienHe),
                 _context.CreateInParameter("DienThoai", DbType.String, model.DienThoai),
                 _context.CreateInParameter("Email", DbType.String, model.Email),
                 _context.CreateInParameter("MaDinhDanhDN", DbType.Int32, model.MaDinhDanhDN),
                 _context.CreateInParameter("TenDoanhNghiep", DbType.String, model.TenDoanhNghiep),
                 _context.CreateInParameter("NoiDungLH", DbType.String, model.NoiDungLH),
                 _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("LienHe_Insert_OR_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion


        #region Xóa dữ liệu

        public async Task<int> DeleteLienHe(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaLienHe", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("LienHe_Delete", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion
    }
}
