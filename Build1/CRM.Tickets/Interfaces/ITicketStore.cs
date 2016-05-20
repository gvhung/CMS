using System;
namespace CRM.Tickets.Interfaces
{
    public interface ITicketStore<TTicket,Tkey>
     where TTicket : CRM.Model.ITicket<Tkey>
    {
        void CreateTicket(TTicket ticket);
    }
}
