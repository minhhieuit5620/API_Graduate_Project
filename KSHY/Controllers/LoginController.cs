//using IS.Model.Manager;
//using KSHY.Models;
//using KSHYDatabase;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using KSHY.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KSHY.Models;
using Microsoft.EntityFrameworkCore;

namespace KSHY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly KHAOSATHYContext _context;

        public LoginController(IConfiguration config, KHAOSATHYContext context)
        {
            _configuration = config;
            _context = context;
        }
       
        [HttpGet, Route("/api/Login/LoginUser")]
        public IActionResult LoginUser(string username, string password)
        {
            TblDoanhNghiep login = new TblDoanhNghiep();

            login.TaiKhoan = username; login.Email=username; login.MatKhau = password;
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);               
                var email = user.Email;
               // var ma = user.MaDinhDanhDn;
                response = Ok(new { token = tokenStr,users= email});
            }
            return response;
        }
        private TblDoanhNghiep AuthenticateUser(TblDoanhNghiep login)
        {
            TblDoanhNghiep user = null;
            var checkUser = _context.TblDoanhNghieps.Where(s => s.TaiKhoan == login.TaiKhoan||s.Email==login.Email && s.MatKhau == login.MatKhau).FirstOrDefault();
            if (checkUser == null)
            {
                return user;
            }
          else
            {
                user = new TblDoanhNghiep { TaiKhoan = login.TaiKhoan, MatKhau = login.MatKhau,TenToChuc=login.TenToChuc,Email=login.Email };
                return user;
            }                  
        }
        private string GenerateJSONWebToken(TblDoanhNghiep userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
           // var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.TaiKhoan),
                // new Claim("Id", userInfo.MaDinhDanhDn.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                //new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"]),
                //new Claim(JwtRegisteredClaimNames.Iss, _config["Jwt:Issuer"])
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims,
                //expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials
            );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        //[Authorize]
        //[HttpPost("Post")]
        //public string Post()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    IList<Claim> claim = identity.Claims.ToList();
        //    var username = claim[0].Value;
        //    return "User " + username + ": Login Successfully!";
        //}
        //[Authorize] //example
        //[HttpGet("GetValue")]
        //public async Task<ActionResult<IEnumerable<string>>> Get()
        //{
        //    return new string[] { "Value1", "Value2", "Value3" };
        //}







        [HttpGet, Route("/api/Login/LoginAdmin")]
        public IActionResult LoginAdmin(string username, string password)
        {
            TblAdmin login = new TblAdmin();

            login.TaiKhoan = username; login.Email = username; login.MatKhau = password;
            IActionResult response = Unauthorized();
            var admin = AuthenticateAdmin(login);
            if (admin != null)
            {
                var tokenStr = GenerateJSONWebTokenAdmin(admin);
                //var tentochuc = login.TenToChuc;
                var adminUser = admin.Email;
                response = Ok(new { token = tokenStr, admin = adminUser });
            }
            return response;
        }
        private TblAdmin AuthenticateAdmin(TblAdmin login)
        {
            TblAdmin admin = null;
            var checkUser = _context.TblAdmins.Where(s => s.TaiKhoan == login.TaiKhoan || s.Email == login.Email && s.MatKhau == login.MatKhau).FirstOrDefault();
            if (checkUser == null)
            {
                return admin;
            }
            else
            {
                admin = new TblAdmin { TaiKhoan = login.TaiKhoan, MatKhau = login.MatKhau, Email = login.Email };
                return admin;
            }
        }
        private string GenerateJSONWebTokenAdmin(TblAdmin adminInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            // var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, adminInfo.TaiKhoan),
                 new Claim("id", adminInfo.Id.ToString()),
                // new Claim(JwtRegisteredClaimNames.Sub, adminInfo.Id),
                //new Claim(JwtRegisteredClaimNames.Sub, adminInfo.TaiKhoan),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                //new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"]),
                //new Claim(JwtRegisteredClaimNames.Iss, _config["Jwt:Issuer"])
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims,
                //expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials
            );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        //[Authorize]
        //[HttpPost("Post")]
        //public string PostAdmin()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    IList<Claim> claim = identity.Claims.ToList();
        //    var username = claim[0].Value;
        //    return "User " + username + ": Login Successfully!";
        //}





        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Post(string username, string password)
        //{

        //    if (username != null && password != null)
        //    {
        //        var user = await GetUser(password, password);

        //        if (user != null)
        //        {
        //            //create claims details based on the user information
        //            var claims = new[] {
        //            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //            //
        //            new Claim("Id", user.MaTaiKhoan.ToString()),
        //            new Claim("FullName", user.MaToChuc.ToString()),
        //            new Claim("UserName", user.TaiKhoan),
        //            //new Claim("Email", users.Email),
        //             // new Claim(ClaimTypes.Role, users.Rol.ToString()),
        //           };

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

        //            return Ok(new
        //            {
        //                user = new
        //                {
        //                    userId = user.MaTaiKhoan,
        //                    fullName = user.MaToChuc,
        //                    userName = user.TaiKhoan,
        //                    role = user.Rol,
        //                },
        //                token = new JwtSecurityTokenHandler().WriteToken(token)
        //            });
        //            // JwtSecurityTokenHandler().WriteToken(token));
        //        }
        //        else
        //        {
        //            return BadRequest("Thông tin tài khoản chưa đúng");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //private async Task<TblTaiKhoanDn> GetUser(string username, string password)
        //{
        //    return await _context.TblTaiKhoanDns.FirstOrDefaultAsync(u => u.TaiKhoan == username && u.MatKhau == password);
        //}

        //Người dùng


        //public IActionResult DangNhap(string username, string pass)
        //{
        //    TblTaiKhoanDn login = new TblTaiKhoanDn();
        //    login.TaiKhoan = username;
        //    login.MatKhau = pass;
        //    IActionResult respon = Unauthorized();
        //}
        //private TblTaiKhoanDn AuthenticateUser(TblTaiKhoanDn user)
        //{
        //    // var dangnhap= _context.TblTaiKhoanDns.FirstOrDefaultAsync(u => u.TaiKhoan == username && u.MatKhau == password);
        //    //TblTaiKhoanDn taikhoan = null;
        //    if ( )
        //}
        //private string GenerateJSONWebToken(TblTaiKhoanDn userInfo)
        //{
        //    var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub,userInfo.TaiKhoan),
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

        //    };
        //    var token = new JwtSecurityToken(
        //        is
        //        )
        //}
    }
}
