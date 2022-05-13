using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KSHY.Models;

namespace KSHY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDoanhNghiepsController : ControllerBase
    {
        private readonly KHAOSATHYContext _context;

        public TblDoanhNghiepsController(KHAOSATHYContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblDoanhNghiep>>> GetDN()
        //{
           
        //}

        // GET: api/TblDoanhNghieps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDoanhNghiep>>> GetTblDoanhNghieps(TblDoanhNghiep DN, int page)
        {
            string StoredProc = "exec DoanhNghiep_Getall " +
                   "@IN_SEARCH_KEYWORD = " + null + "," +
                   "@IN_ADVANCE_QUERY = '" + null + "'," +
                   "@IN_ACTIVE= '" + DN.TrangThai + "'," +
                   "@IN_PAGE= '" + page + "'," +
                   "@IN_PAGE_SIZE= " + 5 + "'";
            return await _context.TblDoanhNghieps.FromSqlRaw(StoredProc).ToListAsync();
            //return await _context.TblDoanhNghieps.ToListAsync();
        }

        // GET: api/TblDoanhNghieps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDoanhNghiep>> GetTblDoanhNghiep(int id)
        {
            var tblDoanhNghiep = await _context.TblDoanhNghieps.FindAsync(id);

            if (tblDoanhNghiep == null)
            {
                return NotFound();
            }

            return tblDoanhNghiep;
        }

        // PUT: api/TblDoanhNghieps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDoanhNghiep(int id, TblDoanhNghiep tblDoanhNghiep)
        {
            if (id != tblDoanhNghiep.MaDoanhNghiep)
            {
                return BadRequest();
            }

            _context.Entry(tblDoanhNghiep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDoanhNghiepExists(id))
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

        // POST: api/TblDoanhNghieps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDoanhNghiep>> PostTblDoanhNghiep(TblDoanhNghiep tblDoanhNghiep)
        {
            _context.TblDoanhNghieps.Add(tblDoanhNghiep);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblDoanhNghiepExists(tblDoanhNghiep.MaDoanhNghiep))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblDoanhNghiep", new { id = tblDoanhNghiep.MaDoanhNghiep }, tblDoanhNghiep);
        }

        // DELETE: api/TblDoanhNghieps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDoanhNghiep(int id)
        {
            var tblDoanhNghiep = await _context.TblDoanhNghieps.FindAsync(id);
            if (tblDoanhNghiep == null)
            {
                return NotFound();
            }

            _context.TblDoanhNghieps.Remove(tblDoanhNghiep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDoanhNghiepExists(int id)
        {
            return _context.TblDoanhNghieps.Any(e => e.MaDoanhNghiep == id);
        }
    }
}
