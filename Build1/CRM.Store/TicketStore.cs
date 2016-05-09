using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.Configuration;
namespace CRM.Store
{
   public class TicketStore : ITicketStore<Ticket>
    {
        ICRMContext _context;
        public TicketStore(ICRMContext context)
        {
            _context = context;
        }

        public void CreateTicket(Ticket ticket)
        {
            Entities.TicketEntity ticketEntity = new Entities.TicketEntity() { TicketNo = (long)ticket.TicketNo, Id = ticket.Id };
            _context.Tickets.Add(ticketEntity);
        }
    }
}
