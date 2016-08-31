using System.Data.Entity;
namespace CRM.DAL.Interfaces
{
    public interface IRepositoryContext
    {
        IDbSet<T> GetEntities<T>() where T : class;

        int SaveChanges();
        void Dispose();
      
      
    }
}
