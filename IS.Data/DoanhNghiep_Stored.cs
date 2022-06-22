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
    public class DoanhNghiep_Stored
    {
        private readonly ISSQLContext _context;

        public DoanhNghiep_Stored(string ConnectString)
        {
            _context = new ISSQLContext(ConnectString);
        }

        #region Lấy dữ liệu
        public async Task<DoanhNghiepReturnModel> GetAllDoanhNghiep(DoanhNghiepModelParameter model)
        {
            IEnumerable<DoanhNghiep_V> resultModel;            
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
            var result = await Task.FromResult(_context.CallToList<DoanhNghiep_V>("DoanhNghiep_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<DoanhNghiep_V>();
            var rs = new DoanhNghiepReturnModel();
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
        public async Task<DoanhNghiepReturnModel> SearchDoanhNghiep(DoanhNghiepModelParameter model,string search)
        {
            IEnumerable<DoanhNghiep_V> resultModel;
           
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
            var result = await Task.FromResult(_context.CallToList<DoanhNghiep_V>("DoanhNghiep_GetList_Or_Search", parameters));
            resultModel = result.Value ?? new List<DoanhNghiep_V>();
            var rs = new DoanhNghiepReturnModel();
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


        public async Task<DoanhNghiep_V> GetDoanhNghiepById(int Id)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDoanhNghiep", DbType.Int32, Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<DoanhNghiep_V>("DoanhNghiep_GetByID", parameters));

            return result.Value;
        }

        public async Task<DoanhNghiep_V> GetDoanhNghiepByName_Or_ByEmail(string name)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("TaiKhoan", DbType.String, name),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToFirstOrDefault<DoanhNghiep_V>("DoanhNghiep_GetbyName_Or_GetbyEmail", parameters));

            return result.Value;
        }

        public async Task<DoanhNghiepReturnModel> GetTinTucByMaLoai(int id)
        {
            List<DoanhNghiep_V> resultModel;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDoanhNghiep", DbType.Int32, id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };
            var result = await Task.FromResult(_context.CallToList<DoanhNghiep_V>("DoanhNghiep_GetByID", parameters));
            resultModel = result.Value ?? new List<DoanhNghiep_V>();
            var rs = new DoanhNghiepReturnModel();
            rs.err_cd = result.ErrorCode;
            rs.err_msg = result.ErrorMessage;
            rs.Data = resultModel.ToList();
            return rs;
        }
        #region Thêm dữ liệu
        public async Task<int> AddOrUpdate(TblDoanhNghieps model)
        {

            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDoanhNghiep", DbType.Int32, model.MaDoanhNghiep),
                    _context.CreateInParameter("MaDinhDanhDN", DbType.Int32, model.MaDinhDanhDn),
                  _context.CreateInParameter("TaiKhoan", DbType.String, model.TaiKhoan),
                    _context.CreateInParameter("MatKhau", DbType.String, model.TenToChuc),
                    _context.CreateInParameter("TenToChuc", DbType.String, model.TenToChuc),
                    _context.CreateInParameter("DiaChi", DbType.String, model.DiaChi),
                    _context.CreateInParameter("TinhThanh", DbType.String, model.TinhThanh),
                    _context.CreateInParameter("DienThoai", DbType.String, model.DienThoai),
                    _context.CreateInParameter("Email", DbType.String, model.Email),
                    _context.CreateInParameter("Website", DbType.String, model.Website),
                    _context.CreateInParameter("NguoiKhaoSat", DbType.String, model.NguoiKhaoSat),
                    _context.CreateInParameter("MaNganh", DbType.Int32, model.MaNganh),
                    _context.CreateInParameter("MaLoaiHinh", DbType.Int32, model.MaLoaiHinh),
                    _context.CreateInParameter("QuyMo", DbType.String, model.QuyMo),
                    _context.CreateInParameter("TieuDe", DbType.String, model.TieuDe),
                    _context.CreateInParameter("MoTa", DbType.String, model.MoTa),
                    _context.CreateInParameter("TrangThai", DbType.Int32, model.TrangThai),              
                    _context.CreateInParameter("Rol", DbType.Int32, model.Rol),
                    _context.CreateInParameter("NguoiTao", DbType.String, model.NguoiTao),
                    _context.CreateInParameter("NguoiSua", DbType.String, model.NguoiSua),
                      _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("DoanhNghiep_Insert_Or_Update", parameters));

            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }
        #endregion

        #region Xóa dữ liệu

        public async Task<int> DeleteDoanhNghiep(int Id)
        {
            var parameters = new List<IDbDataParameter>
                {
                    _context.CreateInParameter("MaDoanhNghiep", DbType.Int32,Id),
                    _context.CreateOutParameter("OUT_ERR_CD", DbType.Int32, 10),
                    _context.CreateOutParameter("OUT_ERR_MSG", DbType.String, 255)
                };

            var result = await Task.FromResult(_context.CallToValue("DoanhNghiep_Delete", parameters));
            return result.ErrorCode == 0 && string.IsNullOrEmpty(result.ErrorMessage) ? Constant.ReturnExcuteFunction.Success : Constant.ReturnExcuteFunction.Error;
        }

        #endregion
    }
}
