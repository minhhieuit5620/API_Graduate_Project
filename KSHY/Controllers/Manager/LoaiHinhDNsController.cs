using IS.Data;
using IS.Model.Views;
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
    public class LoaiHinhDNsController : BaseController
    {

        private LoaiHinhDN_Stored _context;
        public LoaiHinhDNsController(IConfiguration configuration) : base(configuration)
        {

        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/LoaiHinhDN/GetAllLoaiHinhDN")]
        public async Task<IActionResult> GetAllLoaiHinhDN([FromBody] LoaiHinhDN_ModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenLoaiHinh))
            {               
                object data = null;
                _context = new LoaiHinhDN_Stored(ConnectString);
                data = await _context.GetAllLoaiHinhDN(model);
                return Ok(data);              
            }
            return BadRequest("UnAuthorize");

        }
        #endregion
    }
}
