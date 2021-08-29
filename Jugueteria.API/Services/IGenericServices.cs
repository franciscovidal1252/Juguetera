using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.API.Services
{
    public interface IGenericServices<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);
    }
}
