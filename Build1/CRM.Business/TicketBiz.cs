using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Dal;

namespace CRM.Business
{
    public class TicketBiz
    {

        public void AddTicket(Ticket ticket)
        {
            TicketDB ticketdb = new TicketDB();
            ticketdb.AddTicket(ticket);

        }

        public List<Ticket> GetAllTicket()
        {
            TicketDB ticketdb = new TicketDB();
          return ticketdb.GetAllTicket();


        }
    }
}
