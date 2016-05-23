using System.Data.Entity;
using CRM.Store.Entities;

namespace CRM.Store
{
    public interface ICRMContext
    {
        DbSet<TicketEntity> Tickets { get; set; }
        DbSet<ClientEntity> Clients { get; set; }
        DbSet<UserProfileEntity> Users { get; set; }
        DbSet<LoginEntity> Logins { get; set; }



        void SaveChanges();
    }
}