using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CRM.Store.Entities;
namespace CRM.Store
{
    public class CRMContext : DbContext, ICRMContext
    {
        public CRMContext(string constr):base(constr)
        {


        }

        public DbSet<TicketEntity> Tickets { get; set; }

        void ICRMContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
