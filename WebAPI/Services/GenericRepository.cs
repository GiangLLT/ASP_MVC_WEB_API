using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly MyDbContext _context;
        public GenericRepository(MyDbContext Context)
        {
            _context = Context;
        }

        public T Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(string ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public void Update(T ID)
        {
            throw new NotImplementedException();
        }





        //public Header Create(Header T)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(string ID)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Header> GetAll()
        //{
        //    try
        //    {

        //        var All_IDoc = (from s in _context.Idoc_Header
        //                        join r in _context.Idoc_Item on s.IDocNo equals r.IDocNo
        //                        select new Header()
        //                        {
        //                            IDocNo = s.IDocNo,
        //                            IDOCType = s.IDOCType,
        //                            OutDate = s.OutDate,
        //                            SITECode = s.SITECode,
        //                            Body = new List<Body>
        //                            {
        //                                new Body
        //                                {
        //                                    IDocNo         = r.IDocNo          ,
        //                                    EmplCode       = r.EmplCode        ,
        //                                    LastName       = r.LastName        ,
        //                                    FrstName       = r.FrstName        ,
        //                                    DptmCode       = r.DptmCode        ,
        //                                    Job_Cod        = r.Job_Cod         ,
        //                                    CurrShft       = r.CurrShft        ,
        //                                    EmplType       = r.EmplType        ,
        //                                    Gender         = r.Gender          ,
        //                                    Birth_dat      = r.Birth_dat       ,
        //                                    Birth_plc      = r.Birth_plc       ,
        //                                    IC_numbr       = r.IC_numbr        ,
        //                                    IC_numbr_dat   = r.IC_numbr_dat    ,
        //                                    R_Street_numbr = r.R_Street_numbr  ,
        //                                    R_Prov_ID      = r.R_Prov_ID       ,
        //                                    R_Prov_DES     = r.R_Prov_DES      ,
        //                                    R_Dist_ID      = r.R_Dist_ID       ,
        //                                    R_Dist_DES     = r.R_Dist_DES      ,
        //                                    R_Wards_ID     = r.R_Wards_ID      ,
        //                                    R_Wards_DES    = r.R_Wards_DES     ,
        //                                    Street_numbr   = r.Street_numbr    ,
        //                                    Prov_ID        = r.Prov_ID         ,
        //                                    Prov_DES       = r.Prov_DES        ,
        //                                    Dist_ID        = r.Dist_ID         ,
        //                                    Dist_DES       = r.Dist_DES        ,
        //                                    Wards_ID       = r.Wards_ID        ,
        //                                    Wards_DES      = r.Wards_DES       ,
        //                                    Phone_numbr    = r.Phone_numbr     ,
        //                                    Bank_acc_numbr = r.Bank_acc_numbr  ,
        //                                    Bankey_numbr   = r.Bankey_numbr    ,
        //                                    Bank_name      = r.Bank_name

        //                                }
        //                            }
        //                        }).OrderByDescending(x => x.IDocNo);

        //        if (All_IDoc != null)
        //        {
        //            return All_IDoc.ToList();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public Header GetByID(string ID)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Header T)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
