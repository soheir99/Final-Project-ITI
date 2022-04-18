using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Roposityres.Repository
{
    public class ModelRepository<T> : IModelRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext Context;
        protected DbSet<T> Table;

        public ModelRepository(ApplicationDbContext _Context)
        {
            Context = _Context;
            Table = Context.Set<T>();
        }
        public async Task<IQueryable<T>>FindByCondition(Expression<Func<T, bool>> expression)
        {

            return Table.Where(expression).AsNoTracking();
        }
        public  async Task< IQueryable<T>> GetAll()
        {
            return  Table;
        }

        public async Task< T> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> Add(T s)
        {
            await Table.AddAsync(s);
            return s;
        }

        public async Task<T> Update(T entity)
        {
            //var existingEntity = Table.FirstOrDefaultAsync(i => i.Id == entity.Id);//Table.Find(obj.ID);
            //Context.Entry(existingEntity).CurrentValues.SetValues(entity);
            Table.Update(entity);
            return entity;
        }

        public async Task<T> Remove(T entity)
        {
            Table.Remove(entity);
            return entity;
        }

        //public void RemoveByID(int id)
        //{
        //    Table.Remove(GetById(id));
        //}

    }
}