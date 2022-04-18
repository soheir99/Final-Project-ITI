using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roposityres.interfaces
{
    public interface IModelRepository<T>
    {
       Task< IQueryable<T>> GetAll();
       Task< IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);
       Task< T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);

        Task<T> Remove(T entity);
    }
}