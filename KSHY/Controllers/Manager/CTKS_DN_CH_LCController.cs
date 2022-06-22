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
    public class CTKS_DN_CH_LCController : BaseController
    {
        private CTKS_DN_CH_LC_Stored _context;

        public CTKS_DN_CH_LCController(IConfiguration configuration) : base(configuration)
        {

        }
        [HttpPost, Route("/api/CTKS/GetAll")]
        public async Task<IActionResult> GetAllNhomCauHoi()
        {
            //if (!string.IsNullOrEmpty(model.Data.TenToChuc))
            //{
                object data = null;
                _context = new CTKS_DN_CH_LC_Stored(ConnectString);
                data = await _context.GetAllKS();
                return Ok(data);
            //}
            //return BadRequest("UnAuthorize");

        }

        [HttpGet, Route("/api/CTKS/GetCTKSByMaKS/{id}")]
        public async Task<ActionResult<CTKS_DN_CH_LCModelParameter>> GetCTKSByMaKS(int id)
        {
           
               _context = new CTKS_DN_CH_LC_Stored(ConnectString);
            var CTKS = await _context.GetLuaChonByMaCauHoi(id);

            if (CTKS == null)
            {
                return NotFound();
            }

            return Ok(CTKS);
        }


    }
}
