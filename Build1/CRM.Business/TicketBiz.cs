﻿using System;
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
        public int AddTicket(Ticket ticket)
        {
            TicketDB ticketdb = new TicketDB();
            int i = ticketdb.AddTicket(ticket);
            return i;

        }

        public List<Ticket> GetAllTicket(string clientname, int StartIndex, int EndIndex)
        {
            TicketDB ticketdb = new TicketDB();
            return ticketdb.GetAllTicket(clientname, StartIndex, EndIndex);
        }

        //public List<Ticket> GetAllTicket()
        //{
        //    TicketDB ticketdb = new TicketDB();
        //    return ticketdb.GetAllTicket();
        //}

        public Ticket GetTicketById(int id)
        {
            TicketDB ticketdb = new TicketDB();
            Ticket ticket = ticketdb.GetTicketBy(id);
            return ticket;
        }
    }
}
