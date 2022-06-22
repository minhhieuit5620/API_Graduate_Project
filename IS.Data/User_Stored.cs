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
    public class User_Stored
    {
        private readonly ISSQLContext _context;



        public User_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);

        }
        #region Lấy dữ liệu
        public async Task<UserReturnModel> GetAllUser(UserModelParameter model)
        {
            IEnumerable<User> resultModel;

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
            var result = await Task.FromResult(_context.CallToList<User>("Admin_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<User>();
            var rs = new UserReturnModel();
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


        public async Task<UserReturnModel> SearchUser(UserModelParameter model, string search)
        {
            IEnumerable<User> resultModel;


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
            var result = await Task.FromResult(_context.CallToList<User>("Admin_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<User>();
            var rs = new UserReturnModel();
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


        public async Task<User> GetUserById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {

                    _context.CreateInParameter("Id", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToFirstOrDefault<User>("Admin_GetByID", parameters));

            return result.Value;
        }
        public async Task<User> GetUserByName_Or_ByEmail(string name)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("TaiKhoan", DbType.String, name),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<User>("Admin_GetbyName_Or_GetbyEmail", parameters));

            return result.Value;
        }



        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(User model)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("Id", DbType.Int32, model.Id),
                 _context.CreateInParameter("TaiKhoan", DbType.String, model.TaiKhoan),
                 _context.CreateInParameter("MatKhau", DbType.String, model.MatKhau),
                   _context.CreateInParameter("HoVaTen", DbType.String, model.HoVaTen),
                   _context.CreateInParameter("SoDienThoai", DbType.String, model.SoDienThoai),
                   _context.CreateInParameter("Email", DbType.String, model.Email),
                   _context.CreateInParameter("Rol", DbType.Int32, model.Rol),              
                 _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),
                 _context.CreateInParameter("NguoiTao", DbType.String, model.NguoiTao),
                 _context.CreateInParameter("NguoiSua", DbType.String, model.NguoiSua),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("Admin_Insert_OR_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion


        #region Xóa dữ liệu

        public async Task<int> DeleteUser(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("Id", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("Admin_Delete", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion
    }
}
