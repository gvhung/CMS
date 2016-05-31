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
            ticket.DateCreated = DateTime.Now;
            ticket.DateModified = DateTime.Now;
            ticket.DateClosed = null;
            if (ticket.Validate())
           {
                _ticketStore.CreateTicket(ticket);
                //send email to client

            }
        }

        public void UpdateTicket(TTicket ticket)
        {

        }

        public void DeleteTicket(long id)
        {

        }

        public IQueryable<TTicket> GetTickets()
        {

           
            return _ticketStore.GetTickets();
        }

        public IQueryable<TTicket> GetTickets(SearchCriteria criteria)
        {
            return _ticketStore.GetTickets(criteria);
        }
    }
}
