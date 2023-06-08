using Business.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected PrestamoDbContext dbContext;

        public BaseRepository(PrestamoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async virtual Task<TEntity> Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<int> Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async virtual Task<List<TEntity>> GetAll()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetById(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
