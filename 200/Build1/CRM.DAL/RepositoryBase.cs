using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CRM.DAL.Interfaces;
using CRM.DAL.Entities;

namespace CRM.DAL
{
    public abstract class RepositoryBase<T1>:IRepository<T1> where T1: class, IEntity
    {

       public IRepositoryContext Context { get; }

        public RepositoryBase(IRepositoryContext context)
        {
            Context = context;
        }

       
        public void Add(T1 entity)
        {
            Context.GetEntities<T1>().Add(entity);
        }

        public void Update(T1 entity)
        {
            Context.GetEntities<T1>().Attach(entity);
        }

        public void Delete(T1 entity)
        {
            Context.GetEntities<T1>().Remove(entity);
        }

       

        public IList<T1> GetAll(Expression<Func<T1, bool>> whereCondition)
        {
            return Context.GetEntities<T1>().Where(whereCondition).ToList();
        }

        public IQueryable<T1> GetQueryable()
        {
            return Context.GetEntities<T1>().AsQueryable();
        }

        public long Count()
        {
           return Context.GetEntities<T1>().Count();
        }
    }
}
