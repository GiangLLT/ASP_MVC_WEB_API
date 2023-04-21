using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class IdocController : ControllerBase
    {
        private readonly MyDbContext _context;
        private static List<Header> HIdoc = new List<Header> { };
        public IdocController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetIDoc")]
        public IActionResult GetAllIDoc()
        {
            try
            {
                //var All_IDoc = _context.Idoc_Header.ToList();
                //var IDoc_item   = _context.Idoc_Item.ToList();
                //var All_IDoc1 = from t in  _context.Idoc_Header
                //                 join e in _context.Idoc_Item on t.IDocNo equals e.IDocNo
                //                 select t;

                var All_IDoc = (from s in _context.Idoc_Header
                                join r in _context.Idoc_Item on s.IDocNo equals r.IDocNo
                                select new HeaderVM()
                                {
                                    IDocNo = s.IDocNo,
                                    IDOCType = s.IDOCType,
                                    OutDate = s.OutDate,
                                    SITECode = s.SITECode,
                                    Body = new List<BodyVM>
                                    {
                                        new BodyVM
                                        {
                                            IDocNo         = r.IDocNo          ,
                                            EmplCode       = r.EmplCode        ,
                                            LastName       = r.LastName        ,
                                            FrstName       = r.FrstName        ,
                                            DptmCode       = r.DptmCode        ,
                                            Job_Cod        = r.Job_Cod         ,
                                            CurrShft       = r.CurrShft        ,
                                            EmplType       = r.EmplType        ,
                                            Gender         = r.Gender          ,
                                            Birth_dat      = r.Birth_dat       ,
                                            Birth_plc      = r.Birth_plc       ,
                                            IC_numbr       = r.IC_numbr        ,
                                            IC_numbr_dat   = r.IC_numbr_dat    ,
                                            R_Street_numbr = r.R_Street_numbr  ,
                                            R_Prov_ID      = r.R_Prov_ID       ,
                                            R_Prov_DES     = r.R_Prov_DES      ,
                                            R_Dist_ID      = r.R_Dist_ID       ,
                                            R_Dist_DES     = r.R_Dist_DES      ,
                                            R_Wards_ID     = r.R_Wards_ID      ,
                                            R_Wards_DES    = r.R_Wards_DES     ,
                                            Street_numbr   = r.Street_numbr    ,
                                            Prov_ID        = r.Prov_ID         ,
                                            Prov_DES       = r.Prov_DES        ,
                                            Dist_ID        = r.Dist_ID         ,
                                            Dist_DES       = r.Dist_DES        ,
                                            Wards_ID       = r.Wards_ID        ,
                                            Wards_DES      = r.Wards_DES       ,
                                            Phone_numbr    = r.Phone_numbr     ,
                                            Bank_acc_numbr = r.Bank_acc_numbr  ,
                                            Bankey_numbr   = r.Bankey_numbr    ,
                                            Bank_name      = r.Bank_name
                                        }
                                    }
                                }).OrderByDescending(x => x.IDocNo);

                if (All_IDoc != null)
                {                    
                    return Ok(All_IDoc.ToList());
                }
                else
                {
                    return NotFound("Not found data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("GetIDoc/{idoc}")]
        public IActionResult GetByIDoc(string idoc)
        {
            try
            {
                //var GetBy_IDoc = _context.Idoc_Header.SingleOrDefault(i => i.IDocNo == idoc.ToString());
                var GetBy_IDoc = (from s in _context.Idoc_Header
                                  join r in _context.Idoc_Item on s.IDocNo equals r.IDocNo
                                  select new HeaderVM()
                                  {
                                      IDocNo = s.IDocNo,
                                      IDOCType = s.IDOCType,
                                      OutDate = s.OutDate,
                                      SITECode = s.SITECode,
                                      Body = new List<BodyVM>
                                    {
                                        new BodyVM
                                        {
                                            IDocNo         = r.IDocNo          ,
                                            EmplCode       = r.EmplCode        ,
                                            LastName       = r.LastName        ,
                                            FrstName       = r.FrstName        ,
                                            DptmCode       = r.DptmCode        ,
                                            Job_Cod        = r.Job_Cod         ,
                                            CurrShft       = r.CurrShft        ,
                                            EmplType       = r.EmplType        ,
                                            Gender         = r.Gender          ,
                                            Birth_dat      = r.Birth_dat       ,
                                            Birth_plc      = r.Birth_plc       ,
                                            IC_numbr       = r.IC_numbr        ,
                                            IC_numbr_dat   = r.IC_numbr_dat    ,
                                            R_Street_numbr = r.R_Street_numbr  ,
                                            R_Prov_ID      = r.R_Prov_ID       ,
                                            R_Prov_DES     = r.R_Prov_DES      ,
                                            R_Dist_ID      = r.R_Dist_ID       ,
                                            R_Dist_DES     = r.R_Dist_DES      ,
                                            R_Wards_ID     = r.R_Wards_ID      ,
                                            R_Wards_DES    = r.R_Wards_DES     ,
                                            Street_numbr   = r.Street_numbr    ,
                                            Prov_ID        = r.Prov_ID         ,
                                            Prov_DES       = r.Prov_DES        ,
                                            Dist_ID        = r.Dist_ID         ,
                                            Dist_DES       = r.Dist_DES        ,
                                            Wards_ID       = r.Wards_ID        ,
                                            Wards_DES      = r.Wards_DES       ,
                                            Phone_numbr    = r.Phone_numbr     ,
                                            Bank_acc_numbr = r.Bank_acc_numbr  ,
                                            Bankey_numbr   = r.Bankey_numbr    ,
                                            Bank_name      = r.Bank_name
                                        }
                                    }
                                  }).SingleOrDefault(x => x.IDocNo == idoc.ToString());

                if (GetBy_IDoc != null)
                    return Ok(GetBy_IDoc);
                return BadRequest("Not found data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("CreateIDoc")]
        public async Task<ActionResult<List<Header>>> CreateIDoc(Header header_api)
        {
            try
            {
                _context.Add(header_api);
                _context.SaveChanges();
                //return Ok(header_api);
                return Ok(new Notification{
                    Type = "Insert",
                    Message = "Successfull"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            //return Ok(header_api);
        }

        [HttpPut("UpdateIDoc/{idoc}")]
        public async Task<ActionResult<List<Header>>> UpdateIDocByID(string idoc, Header header_api)
        {
            try
            {
                var UpdateBy_IDoc = _context.Idoc_Header.SingleOrDefault(i => i.IDocNo == idoc.ToString());
                if (UpdateBy_IDoc != null)
                {
                    //UpdateBy_IDoc.SITECode = header_api.SITECode;
                    _context.Update(UpdateBy_IDoc);
                    //return Ok(UpdateBy_IDoc);
                    return NoContent();
                }
                else
                {
                    return NotFound("Not found data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
