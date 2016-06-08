using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Tickets.Interfaces;
using CRM.Model;
namespace CRMTicketTest
{
    class DummyTicketStore:ITicketStore<Ticket>
    {
        List<Ticket> _mycontext;
        public DummyTicketStore()
        {
            _mycontext = new List<Ticket>();
        }
        public void CreateTicket(Ticket ticket)
        {
            _mycontext.Add(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            Ticket tempTicket = _mycontext.Find(t => t.TicketNo == ticket.TicketNo);
            if (tempTicket == null)
                throw new Exception("Ticket not found");
            else
                tempTicket = ticket;
        }

        public void DeleteTicket(long Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ticket> GetTickets()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ticket> GetTickets(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
