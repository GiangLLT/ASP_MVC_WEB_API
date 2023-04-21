using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly MyDbContext _context;
        private JwtService _jwtService;
        private IConfiguration _minute;
        public AuthenticationController(MyDbContext context, IConfiguration config)
        {
            _context = context;
            _jwtService = new JwtService(config);
            _minute = config;
            
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto login)
        {
            IActionResult response = Unauthorized();          

            // Kiểm tra tên đăng nhập và mật khẩu
            if (IsValidUser(login))
            {
                // Sinh mã thông báo JWT
                var tokenString = _jwtService.GenerateJwtToken(login.UserName);
                int minute = Convert.ToInt32(_minute["Jwt:ExpiryInMinutes"]);
                var date = DateTime.Now.AddMinutes(minute).ToString("dd-MM-yyyy");
                var time = DateTime.Now.AddMinutes(minute).ToShortTimeString();
                response = Ok(new { token = tokenString, ExpireDate = date, ExpireTime = time });
            }
            else
            {
                return BadRequest("Username or Password not correct!!");
            }    

            return response;
        }


        private bool IsValidUser(UserLoginDto login)
        {
            // Kiểm tra tên đăng nhập và mật khẩu của người dùng
            // Trong ví dụ này, sử dụng thông tin cứng cố định, bạn có thể thay thế bằng kiểm tra trong cơ sở dữ liệu hoặc hệ thống lưu trữ người dùng của bạn
            try
            {
                var users = _context.Users.Where(data => data.Mail == login.UserName && data.Password == login.Password && data.User_Status == true);         
                if (users.Count() >  0)
                    return true;
                else
                {
                    return false;
                }    
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
