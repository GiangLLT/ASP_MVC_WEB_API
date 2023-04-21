using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    interface IGenericRepository <T> where T : class 
    {
        //Task<IEnumerable<T>> GetAll();
        //Task<T> GetByID(int T);
        //Task<T> CreateData( T Entities_Create);
        //Task<T> UpdateData(T Entities_Update);
        //void DeleteData(int Entities_Delete);
        
        List<T> GetAll();
        T GetByID(string ID);
        T Create(T entity);
        void Update(T ID);
        void Delete(T entity);

    }
}
