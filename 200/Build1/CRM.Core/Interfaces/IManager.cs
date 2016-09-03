using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Interfaces
{
    public interface IManager<T> where T: class
    {
        void Create(T model);
        void Update(T model);
        void Remove(T model);
        List<T> GetAll();
        long Count();
        
       // List<T> GetAll(Expression<Func<T, T>> whereCondition);
    }
}
