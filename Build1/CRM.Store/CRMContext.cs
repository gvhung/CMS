using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CRM.Store.Entities;
namespace CRM.Store
{
    public class CRMContext : DbContext
    {
        public CRMContext(string constr) : base(constr)
        {
            
        }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<UserProfileEntity> Users { get; set; }
        public DbSet<LoginEntity> Logins { get; set; }
        public DbSet<CompanyEntity> Clients { get; set; }
        public DbSet<BranchEntity> Branches { get; set; }
        public DbSet<ProductEntity> Products { get; set; }


    }
}
