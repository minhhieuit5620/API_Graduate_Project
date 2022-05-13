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
    public class TinTucController : BaseController
    {
        private TinTuc_Stored _context;
        public TinTucController(IConfiguration configuration) : base(configuration)
        {

        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/TinTuc/GetAllTinTuc")]
        public async Task<IActionResult> GetAllTinTuc([FromBody] TinTucModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TieuDe))
            {
                //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
                //var ArrayAuthorize = strToken.Split(";");
                //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
                //{
                object data = null;
                _context = new TinTuc_Stored(ConnectString);
                data = await _context.GetAllTinTuc(model);
                return Ok(data);
                //}
            }
            return BadRequest("UnAuthorize");

        }


        [HttpGet, Route("/api/TinTuc/GetTinTucByID/{id}")]
        public async Task<ActionResult<TinTucModelParameter>> GetTinTucByID(int id)
        {
            _context = new TinTuc_Stored(ConnectString);
            var tblTinTuc = await _context.GetTinTucById(id);

            if (tblTinTuc == null)
            {
                return NotFound();
            }

            return Ok(tblTinTuc);
        }


        [HttpGet, Route("/api/TinTuc/GetTinTucByMaLoai/{id}")]
        public async Task<ActionResult<CauHoiModelParameter>> GetTinTucByMaLoai(int id)
        {
            _context = new TinTuc_Stored(ConnectString);
            var tblCauHoi = await _context.GetTinTucByMaLoai(id);

            if (tblCauHoi == null)
            {
                return NotFound();
            }

            return Ok(tblCauHoi);
        }

        #endregion


        #region Thêm dữ liệu

        [HttpPost, Route("/api/TinTuc/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] TinTucModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TieuDe))
            {
                //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
                //var ArrayAuthorize = strToken.Split(";");
                //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
                //{
                object data = null;
                var dataModel = model.Data.Cast<TblTinTuc>();
                _context = new TinTuc_Stored(ConnectString);
                data = await _context.AddOrUpdate(dataModel);
                return Ok(data);
                // }
            }
            return BadRequest("UnAuthorize");

        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/TinTuc/Delete_CauHoi/{id}")]
        public async Task<ActionResult<CauHoiModelParameter>> DeleteCauHoi(int id)
        {
            _context = new TinTuc_Stored(ConnectString);
            var tblCauHoi = await _context.DeleteCauHoi(id);
            return Ok(tblCauHoi);
        }
        #endregion
    }
}
