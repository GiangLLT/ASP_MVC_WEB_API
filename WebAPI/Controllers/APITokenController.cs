using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Token;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Net.Http;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class APITokenController : Controller
    {
        private readonly MyDbContext _context;
        private JwtService _jwtService;
        private FunctionAPI _funcAPI;
        private readonly HttpClient _httpClient;

        public APITokenController(MyDbContext context, IConfiguration config)
        {
            _context = context;
            _jwtService = new JwtService(config);
            _funcAPI = new FunctionAPI(_context);
            _httpClient = new HttpClient();
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult<List<Model_API_Users>>> Get()
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                var json_data = _jwtService.VerifyToken(token);
                if (json_data is JsonResult)
                {
                    JsonResult json = json_data as JsonResult;
                    dynamic jsonData = json.Value;
                    if (jsonData.status == true)
                    {
                        var users = _context.Users.OrderByDescending(u => u.ID_user).ToList();
                        return Ok(users);
                    }
                    else
                    {
                        return BadRequest(json);
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            return BadRequest("Not Found");
        }

        [HttpGet("get-by-id-users")]
        public async Task<ActionResult<List<Model_API_Users>>> GetIDByUser(string IDUser)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                var json_data = _jwtService.VerifyToken(token);
                if (json_data is JsonResult)
                {
                    JsonResult json = json_data as JsonResult;
                    dynamic jsonData = json.Value;
                    if (jsonData.status == true)
                    {
                        var users = _context.Users.Where(d => d.ID_user == IDUser);
                        return Ok(users);
                    }
                    else
                    {
                        return BadRequest(json);
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            return BadRequest("Not Found");
        }


        [HttpPost("Create-data-user")]
        public async Task<ActionResult<List<Model_API_Users>>> Post_CreateUser([FromBody] Model_API_Users model)
        {
            try
            {
                Model_API_Status APIstatus = new Model_API_Status();
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null)
                {
                    APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                    APIstatus.DesStatus = "Token is empty";
                    return BadRequest(APIstatus);
                }

                var json_data = _jwtService.VerifyToken(token);
                if (json_data is JsonResult)
                {
                    JsonResult json = json_data as JsonResult;
                    dynamic jsonData = json.Value;
                    if (jsonData.status == true)
                    {
                        if (model == null)
                        {
                            return BadRequest();
                        }
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }
                        // Kiểm tra định dạng email
                        if (!string.IsNullOrEmpty(model.Mail))
                        {
                            try
                            {
                                var mailAddress = new MailAddress(model.Mail);
                            }
                            catch (FormatException)
                            {
                                APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                                APIstatus.DesStatus = "Mail is valid";
                                return BadRequest(APIstatus);
                            }
                        }

                        //Check data password
                        if (string.IsNullOrWhiteSpace(model.Password))
                        {
                            model.Password = "123456789";
                        }
                        else if (model.Password.Length > 100)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "Password is longer than 100 character";
                            return BadRequest(APIstatus);
                        }


                        //Check data phone
                        if (model.Phone.ToString().Length > 10)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "Phone is longer than 10 characters";
                            return BadRequest(APIstatus);
                        }

                        model.ID_user = _funcAPI.GetLastIDuser();
                        model.Acc_Type = "API System";
                        model.User_Status = true;
                        model.Avatar = model.Avatar ?? "";
                        _context.Users.Add(model);
                        await _context.SaveChangesAsync(); // Lưu dữ liệu vào CSDL

                        return Ok(model);
                    }
                    else
                    {
                        return BadRequest(json);
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("update-data-user")]
        //[HttpPut("update-data-user/iduser={IDUser}&mail={Mail)")]
        public async Task<ActionResult<List<Model_API_Users>>> Put_UpdateUser([FromQuery] string IDUser, [FromQuery] string Mail, [FromBody] Model_API_Users model)
        {
            try
            {
                Model_API_Status APIstatus = new Model_API_Status();
                var userToUpdate = new Model_API_Users();
                string token = HttpContext.Request.Headers["Authorization"];
                if (token == null)
                {
                    APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                    APIstatus.DesStatus = "Token is empty!!!";
                    return BadRequest(APIstatus);
                }

                var json_data = _jwtService.VerifyToken(token);
                if (json_data is JsonResult)
                {
                    JsonResult json = json_data as JsonResult;
                    dynamic jsonData = json.Value;
                    if (jsonData.status == true)
                    {

                        //Check data transfer from Parnert
                        if (model == null)
                        {
                            return BadRequest();
                        }

                        // Deserialize model thành đối tượng Model_API_Users
                        if (!string.IsNullOrEmpty(IDUser))
                        {
                            //userToUpdate = await _context.Users.FindAsync(IDUser);
                            //userToUpdate = await _context.Users.FromSqlRaw("SELECT * FROM Admin_users WHERE ID_user = {0}", IDUser, Mail).FirstOrDefaultAsync();
                            userToUpdate = await _context.Users.FromSqlRaw("SELECT * FROM Admin_users WHERE ID_user = {0}", IDUser).FirstOrDefaultAsync();
                            //model.ID_user = userToUpdate.ID_user;
                        }
                        else if (!string.IsNullOrEmpty(Mail))
                        {
                            //userToUpdate = await _context.Users.FindAsync(Mail);
                            userToUpdate = await _context.Users.FromSqlRaw("SELECT * FROM Admin_users WHERE Mail = {0}", Mail).FirstOrDefaultAsync();
                            //model.ID_user = userToUpdate.ID_user;
                        }


                        //check validation
                        if (userToUpdate == null)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "User not found";
                            return BadRequest(APIstatus);
                        }

                        // Kiểm tra các dữ liệu trong model có hợp lệ
                        if (model.ID_user != null)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "ID User can't update";
                            return BadRequest(APIstatus);
                        }

                        if (model.Acc_Type != null)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "Acc Type can't update";
                            return BadRequest(APIstatus);
                        }

                        if (model.Mail != null)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "Mail can't update";
                            return BadRequest(APIstatus);
                        }

                        if (model.Password != null && model.Password.ToString().Length > 100)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "Password is longer than 100 character";
                            return BadRequest(APIstatus);
                        }

                        if (model.Phone == 0 && model.Phone.ToString().Length > 10)
                        {
                            APIstatus.status = StatusCodes.Status400BadRequest.ToString();
                            APIstatus.DesStatus = "Phone is longer than 10 character";
                            return BadRequest(APIstatus);
                        }

                        // Update only non-null fields
                        userToUpdate.ID_user = model.ID_user ?? userToUpdate.ID_user;
                        userToUpdate.Mail = model.Mail ?? userToUpdate.Mail;
                        userToUpdate.Password = model.Password ?? userToUpdate.Password;
                        userToUpdate.FullName = model.FullName ?? userToUpdate.FullName;
                        userToUpdate.displayName = model.displayName ?? userToUpdate.displayName;
                        userToUpdate.Birthday = model.Birthday ?? userToUpdate.Birthday;
                        userToUpdate.Acc_Type = model.Acc_Type ?? userToUpdate.Acc_Type;
                        userToUpdate.Address = model.Address ?? userToUpdate.Address;
                        userToUpdate.Jobtitle = model.Jobtitle ?? userToUpdate.Jobtitle;
                        userToUpdate.Phone = model.Phone ?? userToUpdate.Phone;
                        userToUpdate.Avatar = model.Avatar ?? userToUpdate.Avatar;
                        userToUpdate.User_Status = model.User_Status ?? userToUpdate.User_Status;

                        //_context.Users.Add(model);
                        await _context.SaveChangesAsync(); // Lưu dữ liệu vào CSDL
                        APIstatus.status = StatusCodes.Status200OK.ToString();
                        APIstatus.DesStatus = "Upload Success";
                        return Ok(APIstatus);



                    }
                    else
                    {
                        return BadRequest(json);
                    }
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("delete-by-id-users")]
        public async Task<ActionResult<List<Model_API_Users>>> DeleteIDByUser(string IDUser)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                var json_data = _jwtService.VerifyToken(token);
                if (json_data is JsonResult)
                {
                    JsonResult json = json_data as JsonResult;
                    dynamic jsonData = json.Value;
                    if (jsonData.status == true)
                    {
                        Model_API_Status APIstatus = new Model_API_Status();
                        var userToDelete = _context.Users.Where(d => d.ID_user == IDUser).FirstOrDefault();
                        if (userToDelete != null)
                        {
                            _context.Remove(userToDelete);
                            await _context.SaveChangesAsync();
                            APIstatus.status = StatusCodes.Status200OK.ToString();
                            APIstatus.DesStatus = "Delete Success";
                            return Ok(APIstatus);
                        }
                        else
                        {
                            return BadRequest("Not Found");
                        }

                    }
                    else
                    {
                        return BadRequest(json);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            return BadRequest("Not Found");
        }


        [HttpGet("get-data")]
        public async Task<IActionResult> GetAPIFromOrther()
        {
            try
            {
                // Gọi API từ trang web khác
                HttpResponseMessage response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

                // Kiểm tra xem response có thành công không
                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu trả về từ response
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<Model_API_Post>>(responseContent);
                    var dataList = new List<object>();
                    foreach (var post in posts)
                    {
                        bool sta = false;
                        if(Convert.ToInt32(post.Id) % 2 == 0) {
                            sta = true;
                        }
                        var data = new
                        {
                            PostId = post.Id,
                            UserId = post.UserId,
                            Title = post.Title,
                            Body = post.Body,
                            Status = sta,
                                
                        };
                        dataList.Add(data);
                    }
                    return Ok(dataList);

                }
                else
                {   
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
