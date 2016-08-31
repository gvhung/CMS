using System.Data.Entity;
using CRM.DAL.Entities;
using CRM.DAL.Interfaces;
namespace CRM.DAL
{
    public class CRMContext : DbContext, IRepositoryContext
    {
        
        
        public CRMContext(string constr):base(constr)
        {
         
        }
       
      

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<CRMUser> Users { get; set; }
        public IDbSet<UserType> UserTypes { get; set; }
        public IDbSet<Country> Countries { get; set; }

        public IDbSet<T> GetEntities<T>() where T : class
        {
            return base.Set<T>();
           
        }
    }
}
