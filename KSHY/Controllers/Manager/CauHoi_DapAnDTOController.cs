using KSHY.Models;
using KSHY.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KSHY.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class CauHoi_DapAnDTOController : ControllerBase
    {

        private readonly KHAOSATHYContext _context;

        public CauHoi_DapAnDTOController(KHAOSATHYContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<CauHoi_DapAnDTO>> PostQandA(CauHoi_DapAnDTO QandA)
        {
            _context.TblCauHois.Add(QandA.CauHoi);
            await _context.SaveChangesAsync();
            int id = QandA.CauHoi.MaCauHoi;

            for (int i = 0; i < QandA.LuaChon.Length; i++)
            {
                QandA.LuaChon[i].MaCauHoi = id;

                await _context.TblLuaChons.AddAsync(QandA.LuaChon[i]);
                await _context.SaveChangesAsync();
            };
            return QandA;
        }
        [HttpPost, Route("/api/QandA/PutQandA")]
        public async Task<IActionResult> PutQandAs(int id, CauHoi_DapAnDTO QandA)
        {
            if (id != QandA.CauHoi.MaCauHoi)
            {
                return BadRequest();
            }
            var cauhoi = (from i in _context.TblCauHois where i.MaCauHoi == id select i).FirstOrDefault();

           
            cauhoi.NoiDung = QandA.CauHoi.NoiDung;
            cauhoi.GoiYcauHoi = QandA.CauHoi.GoiYcauHoi;
            cauhoi.MaLoaiCauHoi = QandA.CauHoi.MaLoaiCauHoi;
            cauhoi.MaNhomCauHoi = QandA.CauHoi.MaNhomCauHoi;
            cauhoi.NguoiThem = QandA.CauHoi.NguoiThem;
            cauhoi.NgayThem = QandA.CauHoi.NgayThem;
            cauhoi.NgaySua= QandA.CauHoi.NgaySua;
            cauhoi.NguoiSua = QandA.CauHoi.NguoiSua;
            cauhoi.TrangThai= QandA.CauHoi.TrangThai;

            await _context.SaveChangesAsync();
            var luachon = (from i in _context.TblLuaChons where i.MaCauHoi == id select i).ToList();

           
            for (int i = 0; i < QandA.LuaChon.Length; i++)
            {
                for (int j = 0; j < luachon.Count; j++)
                {
                    luachon[i].MaLuaChon= QandA.LuaChon[i].MaLuaChon;
                    luachon[i].MaCauHoi = QandA.LuaChon[i].MaCauHoi;
                    luachon[i].NoiDung = QandA.LuaChon[i].NoiDung;
                    luachon[i].TrangThai = QandA.LuaChon[i].TrangThai;

                    await _context.SaveChangesAsync();
                    break;
                }
               
            };


            //_context.Entry(QandA).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    return NotFound();
            //    //if (!QandAsExists(id))
            //    //{
            //    //    return NotFound();
            //    //}
            //    //else
            //    //{
            //    //    throw;
            //    //}
            //}

            return NoContent();
        }
        //private bool QandAsExists(int id)
        //{
        //    return _context.CauHoi_DapAnDTO.Any(e => e.Id == id);
        //}







    }
}
