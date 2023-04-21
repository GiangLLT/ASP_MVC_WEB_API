using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class APIController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private static List<WebAPI> WAPI = new List<WebAPI>
        {
             new WebAPI
                {
                    ID            = 1,
                    Sale_Order    = 2000000001,
                    Document_Date = DateTime.Now,
                    Customer      = 90000001,
                    Description   = ""
                },
                 new WebAPI
                {
                    ID            = 2,
                    Sale_Order    = 2000000002,
                    Document_Date = DateTime.Now,
                    Customer      = 90000002,
                    Description   = ""
                }
        };


        [HttpGet("GetSO")]
        public async Task<ActionResult<List<WebAPI>>> Get()
        {
            //var result = new List<WebAPI> { };
            try
            {
                return Ok(WAPI);
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
            return BadRequest("Not Found");
        }

        [HttpGet("GetSO/{order}")]
        public async Task<ActionResult<List<WebAPI>>> Get(int order)
        {
            try
            {
                var api = WAPI.Find(x => x.Sale_Order == order);
                if (api == null)
                    return BadRequest("Not Found");
                return Ok(api);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            //return Ok(WAPI);
        }

        [HttpPost("CreateSO")]
        public async Task<ActionResult<List<WebAPI>>> CreateSO(WebAPI api)
        {
            //var result = new List<WebAPI> { };
            try
            {
                WAPI.Add(api);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            return Ok(WAPI);
        }

        [HttpPut("UpdateSO")]
        public async Task<ActionResult<List<WebAPI>>> UpdateSO(WebAPI request)
        {
            try
            {
                var api = WAPI.Find(x => x.Sale_Order == request.Sale_Order);
                if (api == null)
                    return BadRequest("Not Found");

                api.Document_Date = DateTime.Now;
                api.Description = request.Description;
                return Ok(api);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("DeleteSO/{order}")]
        public async Task<ActionResult<List<WebAPI>>> DeleteSO(int order)
        {
            try
            {
                var api = WAPI.Find(x => x.Sale_Order == order);
                if (api == null)
                    return BadRequest("Not Found");
                WAPI.Remove(api);
                return Ok(api);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            //return Ok(WAPI);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get_API(int order = 0)
        //{
        //    var result = new List<WebAPI> { };
        //    var Api = new List<WebAPI>
        //    {                
        //        new WebAPI
        //        {
        //            ID            = 1,
        //            Sale_Order    = 2000000001,
        //            Document_Date = DateTime.Now,
        //            Customer      = 90000001,
        //            Description   = ""
        //        },
        //         new WebAPI
        //        {
        //            ID            = 2,
        //            Sale_Order    = 2000000002,
        //            Document_Date = DateTime.Now,
        //            Customer      = 90000002,
        //            Description   = ""
        //        }
        //    };

        //    //var result = Api.Select(x => x.Sale_Order = order).ToList();
        //    if(order != 0)
        //    {
        //        result = Api.Where(x => x.Sale_Order == order).ToList();
        //        //return Ok(result);
        //    }    
        //    else
        //    {
        //        return Ok(Api);
        //    }    
        //    return Ok(result);
        //}
    }
}
