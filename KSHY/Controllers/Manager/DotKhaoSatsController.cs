using IS.Data;
using IS.Model.Views;
using KSHY.Models;
using KSHYWeb.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class DotKhaoSatsController : BaseController
    {
        private DotKhaoSat_Stored _context;
        private readonly KHAOSATHYContext context;
        private readonly IWebHostEnvironment _env;
        public DotKhaoSatsController(IConfiguration configuration, IWebHostEnvironment env) : base(configuration)
        {
           
                _env = env;
        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/DotKhaoSat/GetAllDotKhaoSat")]
        public async Task<IActionResult> GetAllDotKhaoSat([FromBody] DotKhaoSatParameter model)
        {

            if (!string.IsNullOrEmpty(model.Data.TenDotKhaoSat))
            {
                object data = null;
                _context = new DotKhaoSat_Stored(ConnectString);
                data = await _context.GetAllDotKhaoSat(model);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");


            //if (!string.IsNullOrEmpty(model.Data.TenToChuc))
            //{
            //    object data = null;
            //    _context = new DoanhNghiep_Stored(ConnectString);
            //    data = await _context.GetAllDoanhNghiep(model);
            //    return Ok(data);
            //}
            //return BadRequest("UnAuthorize");
        }
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [HttpPost, Route("/api/DotKhaoSat/SearchDotKhaoSat/{Search}")]
        public async Task<IActionResult> SearchDotKhaoSat([FromBody] DotKhaoSatParameter model, string Search)
        {
            if (!string.IsNullOrEmpty(model.Data.TenDotKhaoSat))
            {
                object data = null;
                _context = new DotKhaoSat_Stored(ConnectString);
                data = await _context.SearchDotKhaoSat(model, Search);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");

        }

        [HttpGet, Route("/api/DotKhaoSat/GetDotKhaoSatByID/{id}")]
        public async Task<ActionResult<DotKhaoSatParameter>> GetDotKhaoSatByID(int id)
        {
            _context = new DotKhaoSat_Stored(ConnectString);
            var Company = await _context.GetDotKhaoSatById(id);

            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company);
        }

   
        #endregion
        #region Thêm dữ liệu

        [HttpPost, Route("/api/DotKhaoSat/Add_Or_Update")]
        public async Task<IActionResult> Add_Or_Update([FromBody] DotKhaoSatParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenDotKhaoSat))
            {
                object data = null;
                var dataModel = model.Data.Cast<DotKhaoSat>();
                _context = new DotKhaoSat_Stored(ConnectString);
                data = await _context.AddOrUpdate(dataModel);
                return Ok(data);
            }
            return BadRequest("UnAuthorize");
        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/DotKhaoSat/Delete_DotKhaoSat/{id}")]
        public async Task<ActionResult<DotKhaoSatParameter>> DeleteDN(int id)
        {
            _context = new DotKhaoSat_Stored(ConnectString);
            var tblCauHoi = await _context.DeleteDotKhaoSat(id);
            return Ok(tblCauHoi);
        }
        #endregion

    }
}
