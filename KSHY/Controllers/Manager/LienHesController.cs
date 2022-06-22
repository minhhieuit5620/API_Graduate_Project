using IS.Data;
using IS.Model.Manager;
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
    public class LienHesController : BaseController
    {
        private LienHe_Stored _context;
        public LienHesController(IConfiguration configuration) : base(configuration)
        {
        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/LienHe/GetAllLienHe")]
        public async Task<IActionResult> GetAllLienHe([FromBody] LienHeParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNguoiLienHe))
            {
                object data = null;
                _context = new LienHe_Stored(ConnectString);
                data = await _context.GetAllLienHe(model);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }
        [HttpPost, Route("/api/LienHe/SearchLienHe/{Search}")]
        public async Task<IActionResult> SearchLienHe([FromBody] LienHeParameter model, string Search)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNguoiLienHe))
            {
                object data = null;
                _context = new LienHe_Stored(ConnectString);
                data = await _context.SearchLienHe(model, Search);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }
        
        [HttpGet, Route("/api/LienHe/GetLienHeById/{id}")]
        public async Task<ActionResult<LienHeParameter>> GetTblLienHe(int id)
        {
            _context = new LienHe_Stored(ConnectString);
            var tblLienHe = await _context.GetLienHeById(id);

            if (tblLienHe == null)
            {
                return NotFound();
            }

            return Ok(tblLienHe);
        }

        #endregion

        #region Thêm dữ liệu

        [HttpPost, Route("/api/LienHe/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] LienHeParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNguoiLienHe))
            {

                object data = null;
                var dataModel = model.Data.Cast<TblLienHe>();
                _context = new LienHe_Stored(ConnectString);
                data = await _context.AddOrUpdate(dataModel);
                return Ok(data);

            }
            return BadRequest("UnAuthorize");

        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/LienHe/Delete_LienHe/{id}")]
        public async Task<ActionResult<LienHeParameter>> DeleteLienHe(int id)
        {
            _context = new LienHe_Stored(ConnectString);
            var tblLienHe = await _context.DeleteLienHe(id);
            return Ok(tblLienHe);
        }
        #endregion
    }

}
