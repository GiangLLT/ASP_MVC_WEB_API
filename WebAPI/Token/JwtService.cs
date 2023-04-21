using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web.Http.Results;
using Newtonsoft.Json;
using WebAPI.Models;

namespace WebAPI.Token
{
    public class JwtService
    {
        private IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwtToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiryInMinutes"])),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public IActionResult VerifyToken(string token)
        {
            var SecretKey = _config["Jwt:SecretKey"];
            var Issuer = _config["Jwt:Issuer"];
            var Audience = _config["Jwt:Audience"];
            dynamic result = new { };

            // Khóa bí mật để giải mã token
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            try
            {
                // Kiểm tra tính hợp lệ của token
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    // Thiết lập các thông số cho xác thực token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                // Token hợp lệ, lấy thông tin từ token
                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == "sub").Value;
                var expirationDate = jwtToken.ValidTo;

                // Kiểm tra xem token đã hết hạn hay chưa
                if (expirationDate < DateTime.UtcNow)
                {
                    // Token đã hết hạn
                    //return BadRequest("Token has expired");
                    result = new {
                        status = false,
                        DesStatus = "Token has expired",
                        Data = new
                        {
                            Username = "",
                            ExpirationDate = ""
                        }                      
                    };
                    //string BadRequest = Convert.ToString(json_expire);
                    return new JsonResult(result);
                }

                // Token hợp lệ
                //return Ok(new { Username = username, ExpirationDate = expirationDate });
                result = new{
                    status = true,
                    DesStatus = "Token has successed",
                    Data = new
                    {
                        Username = username,
                        ExpirationDate = expirationDate
                    }
                };
                return new JsonResult(result);
            }
            catch (SecurityTokenException)
            {
                // Token không hợp lệ
                //return BadRequest("Invalid token");
                result = new
                {
                    status = false,
                    DesStatus = "Token has expired",
                    Data = new
                    {
                        Username = "",
                        ExpirationDate = ""
                    }
                };
                return new JsonResult(result);
            }
        }
    }
}
