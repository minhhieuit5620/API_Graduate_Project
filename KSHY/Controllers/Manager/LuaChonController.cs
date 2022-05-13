using IS.Data;
using IS.Model.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using KSHYWeb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS.Model.Manager;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuaChonController : BaseController
    {

        private LuaChon _context;
        public LuaChonController(IConfiguration configuration) : base(configuration)
        {

        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/LuaChon/GetAllLuaChon")]
        public async Task<IActionResult> GetAllLuaChon([FromBody] LuaChonModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.NoiDung))
            {
                //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
                //var ArrayAuthorize = strToken.Split(";");
                //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
                //{
                object data = null;
                _context = new LuaChon(ConnectString);
                data = await _context.GetAllLuaChon(model);
                return Ok(data);
                //}
            }
            return BadRequest("UnAuthorize");

        }


        [HttpGet, Route("/api/LuaChon/GetLuaChonById/{id}")]
        public async Task<ActionResult<LuaChonModelParameter>> GetTblLuaChon(int id)
        {
            _context = new LuaChon(ConnectString);
            var tblCauHoi = await _context.GetLuaChonById(id);

            if (tblCauHoi == null)
            {
                return NotFound();
            }

            return Ok(tblCauHoi);
        }


        [HttpGet, Route("/api/LuaChon/GetLuaChonByMaCH/{id}")]
        public async Task<ActionResult<LuaChonModelParameter>> GetLuaChonByMaCH(int id)
        {
            _context = new LuaChon(ConnectString);
            var tblCauHoi = await _context.GetLuaChonByMaCauHoi(id);

            if (tblCauHoi == null)
            {
                return NotFound();
            }

            return Ok(tblCauHoi);
        }

        #endregion


        #region Thêm dữ liệu

        [HttpPost, Route("/api/LuaChon/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] LuaChonModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.NoiDung))
            {
                //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
                //var ArrayAuthorize = strToken.Split(";");
                //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
                //{
                object data = null;
                var dataModel = model.Data.Cast<TblLuaChon>();
                _context = new LuaChon(ConnectString);
                data = await _context.AddOrUpdate(dataModel);
                return Ok(data);
                // }
            }
            return BadRequest("UnAuthorize");

        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/LuaChon/Delete_CauHoi/{id}")]
        public async Task<ActionResult<LuaChonModelParameter>> DeleteCauHoi(int id)
        {
            _context = new LuaChon(ConnectString);
            var tblCauHoi = await _context.DeleteCauHoi(id);
            return Ok(tblCauHoi);
        }
        #endregion
    }
}
