using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Sample.DAL
{
    public interface ICRMContext
    {
        IDbSet<T> Set<T>() where T : class;

        void Save();
        void Dispose();
      
      
    }
}
