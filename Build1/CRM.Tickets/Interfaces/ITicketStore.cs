using System;
using System.Linq;
namespace CRM.Tickets.Interfaces
{
    public interface ITicketStore<TTicket,Tkey>
     where TTicket : CRM.Model.ITicket<Tkey>
    {
        void CreateTicket(TTicket ticket);
        void UpdateTicket(TTicket ticket);
        void DeleteTicket(Tkey Id);
        IQueryable<TTicket> GetTickets();
    }
}
