using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IIDocRepository
    {
        //Task<IEnumerable<T>> GetAll();
        //Task<T> GetByID(int T);
        //Task<T> CreateData( T Entities_Create);
        //Task<T> UpdateData(T Entities_Update);
        //void DeleteData(int Entities_Delete);

        List<Header> GetAll();
        List<Header> GetByID(string ID);
        Header Create(Header entity);
        void Update(Header entity);
        void Delete(string ID);

    }
}
