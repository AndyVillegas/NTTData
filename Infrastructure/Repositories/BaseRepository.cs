using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository
        <TEntityModel> : IBaseRepository<TEntityModel>
        where TEntityModel : class, IEntityModel
    {
        private readonly NTTDATAContext _context;
        public BaseRepository(NTTDATAContext context)
        {
            _context = context;
        }
        public void Create(TEntityModel entity)
        {
            _context.Set<TEntityModel>().Add(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<TEntityModel>().FindAsync(id);
            entity.Estado = false;
            _context.Set<TEntityModel>().Update(entity);
        }

        public void Delete(TEntityModel entity)
        {
            entity.Estado = false;
            _context.Set<TEntityModel>().Update(entity);
        }

        public async Task<TEntityModel> Get(int id)
        {
            var entity = await GetQueryable().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        public async Task<IEnumerable<TEntityModel>> GetAll()
        {
            return await GetQueryable().ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntityModel entity)
        {
            _context.Set<TEntityModel>().Update(entity);
        }
        protected virtual IQueryable<TEntityModel> GetQueryable()
        {
            return _context.Set<TEntityModel>().AsQueryable();
        }
    }
}
