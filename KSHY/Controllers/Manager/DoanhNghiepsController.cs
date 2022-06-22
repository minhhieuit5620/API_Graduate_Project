using IS.Data;
using IS.Model.Manager;
using IS.Model.Views;
using KSHY.Models;
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
    public class DoanhNghiepsController : BaseController
    {
        private DoanhNghiep_Stored _context;
        private readonly KHAOSATHYContext context;
        public DoanhNghiepsController(IConfiguration configuration ) : base(configuration)
        {
          
        }



        #region Lấy dữ liệu
        [HttpPost, Route("/api/DoanhNghiep/GetAllDoanhNghiep")]
        public async Task<IActionResult> GetAllDoanhNghiep([FromBody] DoanhNghiepModelParameter model)
        {
            
            if (!string.IsNullOrEmpty(model.Data.TenToChuc))
            {            
                object data = null;
                _context = new DoanhNghiep_Stored(ConnectString);
                data = await _context.GetAllDoanhNghiep(model);
                return Ok(data);               
            }
            return BadRequest("UnAuthorize");                  
        }

        [HttpPost, Route("/api/DoanhNghiep/SearchDN/{Search}")]
        public async Task<IActionResult> SearchDoanhNghiep([FromBody] DoanhNghiepModelParameter model, string Search)
        {
            if (!string.IsNullOrEmpty(model.Data.TenToChuc))
            {
                object data = null;
                _context = new DoanhNghiep_Stored(ConnectString);
                data = await _context.SearchDoanhNghiep(model, Search);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }

        [HttpGet, Route("/api/DoanhNghiep/GetDoanhNghiepByID/{id}")]
        public async Task<ActionResult<DoanhNghiepModelParameter>> GetDoanhNghiepByID(int id)
        {
            _context = new DoanhNghiep_Stored(ConnectString);
            var Company = await _context.GetDoanhNghiepById(id);

            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }

        //get DN by name or email
        [HttpGet, Route("/api/DoanhNghiep/GetDoanhNghiepByName/{name}")]
        public async Task<ActionResult<DoanhNghiepModelParameter>> GetDoanhNghiepByNameOrEmail(string name)
        {
            _context = new DoanhNghiep_Stored(ConnectString);
            var Company = await _context.GetDoanhNghiepByName_Or_ByEmail(name);

            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }

        #endregion
        #region Thêm dữ liệu

        [HttpPost, Route("/api/DoanhNghiep/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] DoanhNghiepModelParameter model)
        {           
                if (!string.IsNullOrEmpty(model.Data.TenToChuc))
                {
                    object data = null;
                    var dataModel = model.Data.Cast<TblDoanhNghieps>();
                    _context = new DoanhNghiep_Stored(ConnectString);
                    data = await _context.AddOrUpdate(dataModel);
                    return Ok(data);
                }
                return BadRequest("UnAuthorize");                     
        }
        #endregion

    
        #region Xóa dữ liệu
        [HttpPost, Route("/api/DoanhNghiep/Delete_DN/{id}")]
        public async Task<ActionResult<DoanhNghiep_Stored>> DeleteDN(int id)
        {
            _context = new DoanhNghiep_Stored(ConnectString);
            var tblCauHoi = await _context.DeleteDoanhNghiep(id);
            return Ok(tblCauHoi);
        }
        #endregion

    }
}
