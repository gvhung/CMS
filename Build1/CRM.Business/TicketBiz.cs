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
        private readonly TicketDB ticketdb;
        public TicketBiz()
        {
            ticketdb = new TicketDB();
        }

        
        public int AddTicket(Ticket ticket)
        {
            int i = ticketdb.AddTicket(ticket);
            return i;
        }

        public List<Ticket> GetAllTicket(string clientname, int StartIndex, int EndIndex)
        {
            return ticketdb.GetAllTicket(clientname, StartIndex, EndIndex);
        }

        public List<SelectListDTO> BindCompanies()
        {
            List<SelectListDTO> lstCompanies = new List<SelectListDTO>();
            lstCompanies = ticketdb.BindCompanies();
            return lstCompanies;
        }

        public Ticket GetTicketById(int id)
        {
            Ticket ticket = ticketdb.GetTicketBy(id);
            return ticket;
        }

        public List<Seviority> GetSeviorities()
        {
            List<Seviority> ticket = ticketdb.GetSeviorities();
            return ticket;
        }

        public List<Priority> GetPriorities()
        {
            List<Priority> ticket = ticketdb.GetPriorities();
            return ticket;
        }

        public List<TicketType> GetTicketTypes()
        {
            List<TicketType> ticket = ticketdb.GetTicketTypes();
            return ticket;
        }

        public int DeleteTicket(int Id)
        {
            int i = ticketdb.DeleteTicket(Id);
            return i;
        }

        public Templats getTemplate()
        {
            return ticketdb.GetTemplate();
        }

        public Ticket GetTicketNo()
        {
            return ticketdb.GetTicketNo();
        }
    }
}
