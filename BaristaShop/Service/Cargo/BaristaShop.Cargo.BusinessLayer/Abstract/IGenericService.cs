using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        //DataAccessLayer'daki generic ile aynı zaten ona erişmek için kullanıcaz
        Task BInsertAsync(T entity);
        Task BUpdateAsync(T entity);
        Task BDeleteAsync(int id);
        Task<T> BGetByIdAsync(int id);
        Task<List<T>> BGetAllAsync();
    }
}
