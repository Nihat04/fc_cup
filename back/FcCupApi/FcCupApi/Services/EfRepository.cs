using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FcCupApi.Contexts;
using FcCupApi.Entities;
using FcCupApi.Services;

namespace FcCupAp.Services
{
    public class UserRepository<T>: IEfRepository<T> where T : class, IBaseEntity
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(long id) 
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                //todo: need to add logger
                return null;
            }

            return result;
        }

        public async Task<long> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}