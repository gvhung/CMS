using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Tickets.Interfaces;
namespace CRM.Tickets
{
    public class TicketManager<TTicket>  where TTicket: ITicket

    {
        ITicketStore<TTicket> _ticketStore;
        public TicketManager(ITicketStore<TTicket> ticketStore)
        {
            _ticketStore = ticketStore;
        }

        public void CreateTicket(TTicket  ticket)
        {
            if (ticket.Validate())
            {
                _ticketStore.CreateTicket(ticket);
            }
        }

        public void UpdateTicket(TTicket ticket)
        {

        }

        public void DeleteTicket(long id)
        {

        }

        public List<TTicket> GetTickets()
        {
            throw new NotImplementedException();
        }

        public List<TTicket> GetTickets(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
