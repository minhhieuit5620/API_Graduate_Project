using IS.Data;
using IS.Model.Manager;
using IS.Model.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSHYWeb.Extensions;
using ISWeb.Extensions;
using IS.Model;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauHoiController : BaseController
    {


        private CauHoi _context;
        public CauHoiController(IConfiguration configuration) : base(configuration)
        {

        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/CauHoi/GetAllCauHoi")]
        public async Task<IActionResult> GetAllCauHoi([FromBody] CauHoiModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.NoiDung))
            {            
                object data = null;
                _context = new CauHoi(ConnectString);
                data = await _context.GetAllCauHoi(model);
                return Ok(data);
                //}
            }
            return BadRequest("UnAuthorize");
        }

        [HttpPost, Route("/api/CauHoi/GetCauHoiKS")]
        public async Task<IActionResult> GetCauHoiKS([FromBody] CauHoiModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.NoiDung))
            {
                object data = null;
                _context = new CauHoi(ConnectString);
                data = await _context.GetCauHoiKhaoSat(model);
                return Ok(data);
                //}
            }
            return BadRequest("UnAuthorize");

        }

        [HttpPost, Route("/api/CauHoi/SearchCauHoi/{Search}")]
        public async Task<IActionResult> SearchCauHoi([FromBody] CauHoiModelParameter model, string Search)
        {
            if (!string.IsNullOrEmpty(model.Data.NoiDung))
            {
                object data = null;
                _context = new CauHoi(ConnectString);
                data = await _context.SearchCauHoi(model,Search);
                return Ok(data);              
            }
            return BadRequest("UnAuthorize");

        }


        [HttpGet, Route("/api/CauHoi/GetCauHoiById/{id}")]
        public async Task<ActionResult<CauHoiModelParameter>> GetTblCauHoi(int id)
        {
            _context = new CauHoi(ConnectString);
            var tblCauHoi = await _context.GetCauHoiById(id);

            if (tblCauHoi == null)
            {
                return NotFound();
            }

            return Ok(tblCauHoi);
        }


        [HttpGet, Route("/api/CauHoi/GetCauHoiByMaNhom/{id}")]
        public async Task<ActionResult<CauHoiModelParameter>> GetCauHoiKhaoSat(int id)
        {
            _context = new CauHoi(ConnectString);
            var tblCauHoi = await _context.GetCauHoiByMaNhom(id);

            if (tblCauHoi == null)
            {
                return NotFound();
            }

            return Ok(tblCauHoi);
        }

        #endregion


        #region Thêm dữ liệu

        //[HttpPost, Route("/api/CauHoi/Add_Or_Update")]
        //public async Task<IActionResult> Add_Or_Update([FromBody] CauHoiModelParameter model, List<LuaChonModel> luachon)
        //{
        //    if (!string.IsNullOrEmpty(model.Data.NoiDung))
        //    {
        //        //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
        //        //var ArrayAuthorize = strToken.Split(";");
        //        //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
        //        //{
        //        object data = null;
        //        var dataModel = model.Data.Cast<TblCauHoi>();
        //        var dataModelLC = luachon.Cast<TblLuaChon>().ToList();
        //        _context = new CauHoi(ConnectString);
        //        data = await _context.AddOrUpdate(dataModel, dataModelLC);
        //        return Ok(data);
        //        // }
        //    }
        //    return BadRequest("UnAuthorize");

        //}
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/CauHoi/Delete_CauHoi/{id}")]
        public async Task<ActionResult<CauHoiModelParameter>> DeleteCauHoi(int id)
        {
            _context = new CauHoi(ConnectString);
            var tblCauHoi = await _context.DeleteCauHoi(id);
            return Ok(tblCauHoi);
        }
        #endregion
    }
}
