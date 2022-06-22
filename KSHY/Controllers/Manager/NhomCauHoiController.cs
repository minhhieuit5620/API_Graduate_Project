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
                    object data = null;
                    _context = new NhomCauHoi(ConnectString);
                    data = await _context.GetAllNhomCauHoi(model);
                    return Ok(data);               
            }
            return BadRequest("UnAuthorize");

        }
        [HttpPost, Route("/api/Nhom/SearchNCH/{Search}")]
        public async Task<IActionResult> SearchNhomCauHoi([FromBody] NhomCauHoiModelParameter model,string Search)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNhomCauHoi))
            {
                object data = null;
                _context = new NhomCauHoi(ConnectString);
                data = await _context.SearchNhomCauHoi(model,Search);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }

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

        #endregion

        #region Thêm dữ liệu

        [HttpPost, Route("/api/Nhom/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] NhomCauHoiModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNhomCauHoi))
            {
             
                    object data = null;
                    var dataModel = model.Data.Cast<TblNhomCauHoi>();
                    _context = new NhomCauHoi(ConnectString);
                    data = await _context.AddOrUpdate(dataModel);
                    return Ok(data);
            
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
