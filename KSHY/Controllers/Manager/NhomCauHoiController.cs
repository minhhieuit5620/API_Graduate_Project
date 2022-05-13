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
    public class NhomCauHoiController : BaseController
    {



        private NhomCauHoi _context;
        public NhomCauHoiController(IConfiguration configuration) : base(configuration)
        {

        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/Nhom/GetAllNhomCauHoi")]
        public async Task<IActionResult> GetAllNhomCauHoi([FromBody] NhomCauHoiModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNhomCauHoi))
            {
                //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
                //var ArrayAuthorize = strToken.Split(";");
                //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
                //{
                    object data = null;
                    _context = new NhomCauHoi(ConnectString);
                    data = await _context.GetAllNhomCauHoi(model);
                    return Ok(data);
                //}
            }
            return BadRequest("UnAuthorize");

        }
        #endregion

        //[HttpGet, Route("/api/Nhom/GetNhomCauHoiById/'+id+'")]
        //public async Task<IActionResult> GetNhomCauHoiById(int id)
        //{
         
            
        //}

        //[HttpGet("{id}")]
        [HttpGet, Route("/api/Nhom/GetNhomCauHoiById/{id}")]
        public async Task<ActionResult<NhomCauHoiModelParameter>> GetTblNhomCauHoi(int id)
        {
            _context = new NhomCauHoi(ConnectString);
            var tblNhomCauHoi = await _context.GetNhomCauHoiById(id);

            if (tblNhomCauHoi == null)
            {
                return NotFound();
            }

            return Ok(tblNhomCauHoi);
        }



        #region Thêm dữ liệu

        [HttpPost, Route("/api/Nhom/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] NhomCauHoiModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNhomCauHoi))
            {
                //var strToken = ISSecurity.DecryptASCII(model.Data.Key, _systemRoot.Key, true);
                //var ArrayAuthorize = strToken.Split(";");
                //if (ArrayAuthorize[0] == _systemRoot.Value && lstAccessSystem.Any(a => a == ArrayAuthorize[1]))
                //{
                    object data = null;
                    var dataModel = model.Data.Cast<TblNhomCauHoi>();
                    _context = new NhomCauHoi(ConnectString);
                    data = await _context.AddOrUpdate(dataModel);
                    return Ok(data);
               // }
            }
            return BadRequest("UnAuthorize");

        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/Nhom/Delete_NhomCauHoi/{id}")]
        public async Task<ActionResult<NhomCauHoiModelParameter>> DeleteNhomCauHoi(int id)
        {
            _context = new NhomCauHoi(ConnectString);
            var tblNhomCauHoi = await _context.DeleteNhomCauHoi(id);
            return Ok(tblNhomCauHoi);
        }
        #endregion
    }
}
