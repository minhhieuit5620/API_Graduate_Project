using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSHY.Models.DTO;
using KSHY.Models;

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhaoSat_DTOController : ControllerBase
    {
        private readonly KHAOSATHYContext _context;

        public KhaoSat_DTOController(KHAOSATHYContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<KhaoSatDTO>> PostTblNhomCauHoi(KhaoSatDTO KhaosatDTO)
        {
            _context.TblKhaoSats.Add(KhaosatDTO.KhaoSat);
            await _context.SaveChangesAsync();
            int id = KhaosatDTO.KhaoSat.MaKhaoSat;

            for (int i = 0; i < KhaosatDTO.CTKS.Length; i++)
            {
                KhaosatDTO.CTKS[i].MaKhaoSat = id;

                await _context.TblChiTietKhaoSats.AddAsync(KhaosatDTO.CTKS[i]);
                await _context.SaveChangesAsync();
            };
            return KhaosatDTO;
        }

    }
}
