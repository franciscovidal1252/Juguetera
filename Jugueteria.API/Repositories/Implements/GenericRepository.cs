using Jugueteria.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly JugueteriaDbContext jugueteriaDbContext;

        public GenericRepository(JugueteriaDbContext jugueteriaDbContext)
        {
            this.jugueteriaDbContext = jugueteriaDbContext;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("El Articulo es nulo");
            }

            jugueteriaDbContext.Set<TEntity>().Remove(entity);
            await jugueteriaDbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await jugueteriaDbContext.Set<TEntity>().ToListAsync();

        }

        public async Task<TEntity> GetById(int id)
        {
            return await jugueteriaDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await jugueteriaDbContext.Set<TEntity>().AddAsync(entity);
            await jugueteriaDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            jugueteriaDbContext.Set<TEntity>().Update(entity);
            await jugueteriaDbContext.SaveChangesAsync();
            return entity;
        }
    }
}