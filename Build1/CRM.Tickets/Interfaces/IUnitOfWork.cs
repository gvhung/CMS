using System;
namespace CRM.Tickets.Interfaces
{
   public interface IUnitOfWork
    {
        void Dispose();
        void SaveChanges();
        CRM.Tickets.Interfaces.ITicketStore<CRM.Model.Ticket> TiketStore { get; }
    }
}
