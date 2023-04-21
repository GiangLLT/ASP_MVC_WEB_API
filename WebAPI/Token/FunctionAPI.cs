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
    public class FunctionAPI
    {
        private readonly MyDbContext _context;
        public FunctionAPI(MyDbContext context)
        {
            _context = context;
        }
        public string GetLastIDuser()
        {
            var User_data = _context.Users.OrderByDescending(u => u.ID_user).First();
            if (User_data != null)
            {
                string id = User_data.ID_user;
                int number = Convert.ToInt32(id.Substring(1)) + 1; // Chuyển đổi chuỗi sang kiểu số nguyên và thực hiện phép toán cộng 1
                string userID = "U" + number.ToString().PadLeft(9, '0');
                //string userID = "U" + (int.Parse(id.ToString().Substring(1)) + 1).ToString().PadLeft(9, '0');
                return userID;
            }
            else
            {
                string UserID = "U000000001";
                return UserID ;
            }
                
        }
    }
}
