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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinTucController : BaseController
    {
        private TinTuc_Stored _context;
        private readonly IWebHostEnvironment _env;
        public TinTucController(IConfiguration configuration, IWebHostEnvironment env) : base(configuration)
        {
            _env = env;
        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/TinTuc/GetAllTinTuc")]
        public async Task<IActionResult> GetAllTinTuc([FromBody] TinTucModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TieuDe))
            {                
                object data = null;
                _context = new TinTuc_Stored(ConnectString);
                data = await _context.GetAllTinTuc(model);
                return Ok(data);           
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
                object data = null;
                var dataModel = model.Data.Cast<TblTinTuc>();
                _context = new TinTuc_Stored(ConnectString);
                data = await _context.AddOrUpdate(dataModel);
                return Ok(data);              
            }
            return BadRequest("UnAuthorize");

        }
        #endregion


        #region Xóa dữ liệu
        [HttpPost, Route("/api/TinTuc/Delete_TinTuc/{id}")]
        public async Task<ActionResult<CauHoiModelParameter>> DeleteCauHoi(int id)
        {
            _context = new TinTuc_Stored(ConnectString);
            var tblCauHoi = await _context.DeleteTinTuc(id);
            return Ok(tblCauHoi);
        }
        #endregion

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

    }
}
