using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IProxyRepository
    {
        //Task<IEnumerable<T>> GetAll();
        //Task<T> GetByID(int T);
        //Task<T> CreateData( T Entities_Create);
        //Task<T> UpdateData(T Entities_Update);
        //void DeleteData(int Entities_Delete);

        List<HeaderVM> GetAll();
        List<HeaderVM> GetByID(string ID);
        HeaderVM Create(HeaderVM entity);
        void Update(HeaderVM entity);
        void Delete(string ID);

    }
}
