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
    public class NganhKDsController : BaseController
    {

        private NganhKD_Stored _context;
        public NganhKDsController(IConfiguration configuration) : base(configuration)
        {

        }
        #region Lấy dữ liệu
        [HttpPost, Route("/api/NganhKD/GetAllNganhKD")]
        public async Task<IActionResult> GetAllNganhKD([FromBody] NganhKD_ModelParameter model)
        {
            if (!string.IsNullOrEmpty(model.Data.TenNganh))
            {               
                object data = null;
                _context = new NganhKD_Stored(ConnectString);
                data = await _context.GetAllNganhKD(model);
                return Ok(data);              
            }
            return BadRequest("UnAuthorize");

        }
        #endregion
    }
}
