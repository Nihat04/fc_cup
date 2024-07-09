using System.Collections.Generic;
using System.Threading.Tasks;

namespace FcCupApi.Services
{
    public interface IEfRepository<T>
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);
    }
}