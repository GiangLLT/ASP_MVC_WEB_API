using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class IDocRepository : IIDocRepository
    {
        private readonly MyDbContext _context;
        public IDocRepository(MyDbContext Context)
        {
            _context = Context;
        }
        public Header Create(Header entity)
        {
            try
            {
                var list = entity.Body.ToList();
                _context.Add(entity);
                _context.SaveChanges();
                //return Ok(header_api);
                return new Header()
                {
                    IDocNo = entity.IDocNo,
                    IDOCType = entity.IDOCType,
                    OutDate = entity.OutDate,
                    SITECode = entity.SITECode,
                    Body = new List<Body>
                            {
                                new Body
                                {
                                    IDocNo         = list[0].IDocNo          ,
                                    EmplCode       = list[0].EmplCode        ,
                                    LastName       = list[0].LastName        ,
                                    FrstName       = list[0].FrstName        ,
                                    DptmCode       = list[0].DptmCode        ,
                                    Job_Cod        = list[0].Job_Cod         ,
                                    CurrShft       = list[0].CurrShft        ,
                                    EmplType       = list[0].EmplType        ,
                                    Gender         = list[0].Gender          ,
                                    Birth_dat      = list[0].Birth_dat       ,
                                    Birth_plc      = list[0].Birth_plc       ,
                                    IC_numbr       = list[0].IC_numbr        ,
                                    IC_numbr_dat   = list[0].IC_numbr_dat    ,
                                    R_Street_numbr = list[0].R_Street_numbr  ,
                                    R_Prov_ID      = list[0].R_Prov_ID       ,
                                    R_Prov_DES     = list[0].R_Prov_DES      ,
                                    R_Dist_ID      = list[0].R_Dist_ID       ,
                                    R_Dist_DES     = list[0].R_Dist_DES      ,
                                    R_Wards_ID     = list[0].R_Wards_ID      ,
                                    R_Wards_DES    = list[0].R_Wards_DES     ,
                                    Street_numbr   = list[0].Street_numbr    ,
                                    Prov_ID        = list[0].Prov_ID         ,
                                    Prov_DES       = list[0].Prov_DES        ,
                                    Dist_ID        = list[0].Dist_ID         ,
                                    Dist_DES       = list[0].Dist_DES        ,
                                    Wards_ID       = list[0].Wards_ID        ,
                                    Wards_DES      = list[0].Wards_DES       ,
                                    Phone_numbr    = list[0].Phone_numbr     ,
                                    Bank_acc_numbr = list[0].Bank_acc_numbr  ,
                                    Bankey_numbr   = list[0].Bankey_numbr    ,
                                    Bank_name      = list[0].Bank_name
                                }
                            }
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Delete(string ID)
        {
            throw new NotImplementedException();
        }

        public List<Header> GetAll()
        {
            try
            {
                var All_IDoc = (from s in _context.Idoc_Header
                                join r in _context.Idoc_Item on s.IDocNo equals r.IDocNo
                                select new Header()
                                {
                                    IDocNo = s.IDocNo,
                                    IDOCType = s.IDOCType,
                                    OutDate = s.OutDate,
                                    SITECode = s.SITECode,
                                    Body = new List<Body>
                                        {
                                            new Body
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

                //var All_IDoc = (from s in _context.Idoc_Header
                //                join r in _context.Idoc_Item on s.IDocNo equals r.IDocNo
                //                select new {s,r}).OrderByDescending(x => x.r.IDocNo).ToList();

                if (All_IDoc != null)
                {
                    return All_IDoc.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Header> GetByID(string ID)
        {
            try
            {
                var All_IDoc = (from s in _context.Idoc_Header
                                join r in _context.Idoc_Item on s.IDocNo equals r.IDocNo
                                select new Header()
                                {
                                    IDocNo = s.IDocNo,
                                    IDOCType = s.IDOCType,
                                    OutDate = s.OutDate,
                                    SITECode = s.SITECode,
                                    Body = new List<Body>
                                        {
                                            new Body
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
                                }).Where(x=> x.IDocNo == ID.ToString()).OrderByDescending(x => x.IDocNo);

                if (All_IDoc != null)
                {
                    return All_IDoc.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(Header entity)
        {
            throw new NotImplementedException();
        }
    }
}
