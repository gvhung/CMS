using System.Data.Entity;
using CRM.DAL.Entities;
using CRM.DAL.Interfaces;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRM.DAL
{
    public class CRMContext : DbContext, IRepositoryContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public CRMContext(string constr):base(constr)
        {
         
        }
       
      

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<CRMUser> Users { get; set; }
        public IDbSet<UserType> UserTypes { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Ticket>  Tickets { get; set; }
        public IDbSet<TicketAttachment> TicketAttachments { get; set; }
        public IDbSet<TicketComment>  TicketComments { get; set; }
        public IDbSet<StatusMaster> StatusMasters { get; set; }
        public IDbSet<T> GetEntities<T>() where T : class
        {
            return base.Set<T>();
           
        }
    }
}
