using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<int> Delete(TEntity entity);

        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

    }
    
}
