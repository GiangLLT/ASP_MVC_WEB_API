using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IIDocRepository _IdocRepository;
        private readonly IProxyRepository _ProxyRepository;
        public HeaderController (IIDocRepository iDocRepository, IProxyRepository iProxyRepository)
        {
            _IdocRepository  = iDocRepository;
            _ProxyRepository = iProxyRepository;
        }

        //private readonly IProxyRepository _ProxyRepository;
        //public HeaderController(IProxyRepository iProxyRepository)
        //{
        //    _ProxyRepository = iProxyRepository;
        //}

        //Properties HeaderVM BodyVM

        [HttpGet("GetIDoc")]
        public IActionResult GetAllHeaderVM()
        {
            try
            {
                var getall = _ProxyRepository.GetAll();
                if (getall != null)
                {
                    return Ok(getall);
                }
                else
                    return NotFound();
                //return Ok(_IdocRepository.GetAll());                
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetIDocByID")]
        public IActionResult GetIDocHeaderByID(string ID)
        {
            try
            {
                var getall = _ProxyRepository.GetByID(ID);
                if (getall != null)
                {
                    return Ok(getall);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpPost("CreateIdocVM")]
        //public IActionResult CreateIdoc(HeaderVM entity)
        //{
        //    try
        //    {
        //        var getall = _ProxyRepository.Create(entity);
        //        if (getall != null)
        //        {
        //            //return Ok(getall);
        //            return StatusCode(StatusCodes.Status200OK);
        //        }
        //        else
        //            return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        //return BadRequest(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //Properties Header Body

        [HttpGet("GetIDocHeader")]
        public IActionResult GetAllHeader()
        {
            try
            {
                var getall = _IdocRepository.GetAll();
                if (getall != null)
                {
                    return Ok(getall);
                }
                else
                    return NotFound();
                //return Ok(_IdocRepository.GetAll());                
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpGet("GetIDocHeaderByID")]
        //public IActionResult GetIDocByID(string ID)
        //{
        //    try
        //    {
        //        var getall = _IdocRepository.GetByID(ID);
        //        if (getall != null)
        //        {
        //            return Ok(getall);
        //        }
        //        else
        //            return NotFound();          
        //    }
        //    catch (Exception ex)
        //    {
        //        //return BadRequest(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        [HttpPost("CreateIdoc")]
        public IActionResult CreateIdocVM(Header entity)
        {
            try
            {
                var getall = _IdocRepository.Create(entity);
                if (getall != null)
                {
                    //return Ok(getall);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                    return NotFound();             
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
