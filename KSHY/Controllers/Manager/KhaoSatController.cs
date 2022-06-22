using KSHY.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSHY.Models;
using IS.Model.Views;
using IS.Data;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhaoSatController : BaseController
    {
        private KhaoSat _context;
        private readonly KHAOSATHYContext context;
        public KhaoSatController(IConfiguration configuration) : base(configuration)
        {

        }


        //[HttpPost("test")]
        //public async Task<ActionResult<IEnumerable<TblKhaoSat>>> KhaoSat(result rl)
        //{
        //    return _context.TblKhaoSats.ToList();
        //}

        #region Lấy dữ liệu
        [HttpPost, Route("/api/KhaoSat/GetAllKhaoSat")]
        public async Task<IActionResult> GetAllDoanhNghiep([FromBody] KhaoSatModelParameter model)
        {
            
            if (!string.IsNullOrEmpty(model.Data.MaKhaoSat.ToString()))
            {              
                object data = null;
                _context = new KhaoSat(ConnectString);
                data = await _context.GetAllKhaoSat(model);
                return Ok(data);             
            }
            return BadRequest("UnAuthorize");
        }

        #endregion
        //[HttpPost, Route("/api/CauHoi/Delete_CauHoi/{id}")]
        //public async Task<ActionResult<CauHoiModelParameter>> DeleteCauHoi(int id)
        //{
        //    _context = new CauHoi(ConnectString);
        //    var tblCauHoi = await _context.DeleteCauHoi(id);
        //    return Ok(tblCauHoi);
        //}
        #region Xóa dữ liệu
        [HttpPost, Route("/api/KhaoSat/Delete_KhaoSat/{id}")]
        public async Task<ActionResult<KhaoSatModelParameter>> DeleteKhaoSat(int id)
        {
            _context = new KhaoSat(ConnectString);
            var khaosat = await _context.DeleteKhaoSat(id);
            return Ok(khaosat);
        }

        [HttpPost, Route("/api/KhaoSat/Delete_CTKhaoSat/{id}")]
        public async Task<ActionResult<CTKhaoSatModelParameter>> DeleteCTKhaoSat(int id)
        {
            _context = new KhaoSat(ConnectString);
            var khaosat = await _context.DeleteCTKhaoSat(id);
            return Ok(khaosat);
        }
        #endregion

    }
}
