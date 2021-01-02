using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TwitchEShop.Domain.Interfaces
{
   public  interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T t);
        Task<bool> UpdateAsync(T t);
        Task<bool> DeleteAsync(int id);

        //repository pattern
        //Unit of work pattern
        //Inversion of control (dependency injection)
        //lazy vs eager loading
        //why use dtos
    }
}
