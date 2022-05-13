using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KSHY.Models;
using Microsoft.Data.SqlClient;

namespace KSHY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblNhomCauHoisController : ControllerBase
    {
        private readonly KHAOSATHYContext _context;

        public TblNhomCauHoisController(KHAOSATHYContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNhomCauHoi>>> GetTblNhomCauHois() {
            return await _context.TblNhomCauHois.ToListAsync();
        
        }
        // GET: api/TblNhomCauHois
        [Route("/api/TblNhomCauHoi/GetDN/")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TblNhomCauHoi>>> GetNhomCauHoi(int page )
        {
            int active = 1;
            int pagesize = 5;            
            string StoredProc =
                    "DECLARE @return_value int," +
                   " @OUT_TOTAL_ROW int," +
                    " @OUT_ERR_CD int," +
                     "@OUT_ERR_MSG nvarchar(max)" +
                "exec NhomCauHoi_Getall " +
                   "@IN_SEARCH_KEYWORD = NULL," +
                   "@IN_ADVANCE_QUERY = NULL," +
                   "@IN_ACTIVE= " + active + "," +
                   "@IN_PAGE= " + page + "," +
                   "@IN_PAGE_SIZE= " + pagesize + "," +
                    " @OUT_TOTAL_ROW = @OUT_TOTAL_ROW OUTPUT," +
                     "@OUT_ERR_CD = @OUT_ERR_CD OUTPUT," +
                      "@OUT_ERR_MSG = @OUT_ERR_MSG OUTPUT";              
		    return await _context.TblNhomCauHois.FromSqlRaw(StoredProc).ToListAsync();
        }
            // GET: api/TblNhomCauHois/5
            [HttpGet("{id}")]
        public async Task<ActionResult<TblNhomCauHoi>> GetTblNhomCauHoi(int id)
        {
            var tblNhomCauHoi = await _context.TblNhomCauHois.FindAsync(id);

            if (tblNhomCauHoi == null)
            {
                return NotFound();
            }

            return tblNhomCauHoi;
        }

        // PUT: api/TblNhomCauHois/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNhomCauHoi(int id, TblNhomCauHoi tblNhomCauHoi)
        {
            if (id != tblNhomCauHoi.MaNhomCauHoi)
            {
                return BadRequest();
            }

            _context.Entry(tblNhomCauHoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNhomCauHoiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblNhomCauHois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblNhomCauHoi>> PostTblNhomCauHoi(TblNhomCauHoi tblNhomCauHoi)
        {
            _context.TblNhomCauHois.Add(tblNhomCauHoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblNhomCauHoi", new { id = tblNhomCauHoi.MaNhomCauHoi }, tblNhomCauHoi);
        }

        // DELETE: api/TblNhomCauHois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblNhomCauHoi(int id)
        {
            var tblNhomCauHoi = await _context.TblNhomCauHois.FindAsync(id);
            if (tblNhomCauHoi == null)
            {
                return NotFound();
            }

            _context.TblNhomCauHois.Remove(tblNhomCauHoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblNhomCauHoiExists(int id)
        {
            return _context.TblNhomCauHois.Any(e => e.MaNhomCauHoi == id);
        }
    }
}
