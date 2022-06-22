using IS.Data;
using IS.Model.Views;
using KSHYWeb.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private User_Stored _context;
        public UsersController(IConfiguration configuration) : base(configuration)
        {
        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/User/GetAllUser")]
        public async Task<IActionResult> GetAllUser([FromBody] UserModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TaiKhoan))
            {
                object data = null;
                _context = new User_Stored(ConnectString);
                data = await _context.GetAllUser(model);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }
        [HttpPost, Route("/api/User/SearchUser/{Search}")]
        public async Task<IActionResult> SearchUser([FromBody] UserModelParameter model, string Search)
        {
            if (!string.IsNullOrEmpty(model.Data.TaiKhoan))
            {
                object data = null;
                _context = new User_Stored(ConnectString);
                data = await _context.SearchUser(model, Search);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }

        [HttpGet, Route("/api/User/GetUserById/{id}")]
        public async Task<ActionResult<NhomCauHoiModelParameter>> GetUserById(int id)
        {
            _context = new User_Stored(ConnectString);
            var Admin = await _context.GetUserById(id);

            if (Admin == null)
            {
                return NotFound();
            }

            return Ok(Admin);
        }
        [HttpGet, Route("/api/User/GetUserByNameOrEmail/{name}")]
        public async Task<ActionResult<DoanhNghiepModelParameter>> GetUserByNameOrEmail(string name)
        {
            _context = new User_Stored(ConnectString);
            var Company = await _context.GetUserByName_Or_ByEmail(name);

            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }

        #endregion

        #region Thêm dữ liệu

        [HttpPost, Route("/api/User/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] UserModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TaiKhoan))
            {

                object data = null;
                var dataModel = model.Data.Cast<User>();
                _context = new User_Stored(ConnectString);
                data = await _context.AddOrUpdate(dataModel);
                return Ok(data);

            }
            return BadRequest("UnAuthorize");

        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/User/Delete_User/{id}")]
        public async Task<ActionResult<NhomCauHoiModelParameter>> DeleteNhomCauHoi(int id)
        {
            _context = new User_Stored(ConnectString);
            var Admin = await _context.DeleteUser(id);
            return Ok(Admin);
        }
        #endregion
    }
}
