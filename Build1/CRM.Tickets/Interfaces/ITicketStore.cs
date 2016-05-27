﻿using System;
using System.Linq;
namespace CRM.Tickets.Interfaces
{
    public interface ITicketStore<TTicket>
     where TTicket : CRM.Model.ITicket
    {
        void CreateTicket(TTicket ticket);
        void UpdateTicket(TTicket ticket);
        void DeleteTicket(long Id);
        IQueryable<TTicket> GetTickets();
                
    }
}
