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
    public class CauHoiDTOController : BaseController
    {
        private CauHoiDTO _context;
        public CauHoiDTOController(IConfiguration configuration) : base(configuration)
        {

        }
        [HttpPost, Route("/api/CauHoi_LuaChon_DTO/GetAll")]
        public async Task<IActionResult> GetAllCauHoi_LuaChon_DTO([FromBody] CauHoi_DTO_VModelParameter model)
        {
            //if (!string.IsNullOrEmpty(model.Data.NoiDung))
            //{
                object data = null;
                _context = new CauHoiDTO(ConnectString);
                data = await _context.GetAllCauHoi_LuaChon_DTO(model);
                return Ok(data);
            //}
            //return BadRequest("UnAuthorize");

        }
        [HttpGet, Route("/api/CauHoi_LuaChon_DTO/GetCauHoi_LuaChon_DTOById/{id}")]
        public async Task<ActionResult<LuaChonModelParameter>> tblCauHoi_LuaChon(int id)
        {
            object data = null;
            _context = new CauHoiDTO(ConnectString);
            data = await _context.GetCauHoi_LuaChonById(id);
            return Ok(data);
        }
    }
}
