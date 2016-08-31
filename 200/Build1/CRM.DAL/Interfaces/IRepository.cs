using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using CRM.DAL.Entities;

namespace CRM.DAL.Interfaces
{
    public interface IRepository<T1> where T1:class, IEntity
    {
        void Add(T1 entity);
        void Update(T1 entity);
        void Delete(T1 entity);
       
        IList<T1> GetAll(Expression<Func<T1, bool>> whereCondition);
        IQueryable<T1> GetQueryable();
        long Count();


    }
}
