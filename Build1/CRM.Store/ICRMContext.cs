using System.Data.Entity;
using CRM.Store.Entities;

namespace CRM.Store
{
    public interface ICRMContext
    {
        DbSet<TicketEntity> Tickets { get; set; }
    }
}