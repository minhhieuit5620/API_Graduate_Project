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
    public class KhaoSat_DNController : BaseController
    {
        private KhaoSat_DN_Stored _context;
       // private readonly KHAOSATHYContext context;
        public KhaoSat_DNController(IConfiguration configuration) : base(configuration)
        {

        }



        #region Lấy dữ liệu
        [HttpPost, Route("/api/DoanhNghiep/GetKhaoSat_DN")]
        public async Task<IActionResult> GetKhaoSat_DN([FromBody] KhaoSat_DNModelParameter model)
        {

            //if (!string.IsNullOrEmpty(model.Data.TenToChuc))
            //{
                object data = null;
                _context = new KhaoSat_DN_Stored(ConnectString);
                data = await _context.GetDataKhaoSat_DN(model);
                return Ok(data);
           // }
            //return BadRequest("UnAuthorize");



        }
    }
}
#endregion