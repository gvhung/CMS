using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Store.Entities;
using CRM.Tickets.Interfaces;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
namespace CRM.Store
{
    public class TicketStore<TTicket> : ITicketStore<TTicket> where TTicket:ITicket
    {
        ICRMContext _context;
        public TicketStore(ICRMContext context)
        {
            _context = context;
        }
        public void CreateTicket(TTicket ticket)
        {
            
            TicketEntity ticketEntity=(TicketEntity) AutoMapper.Mapper.Map<TicketEntity>(ticket);
                

            _context.Tickets.Add(ticketEntity);
            _context.SaveChanges();
        }



        public void UpdateTicket(TTicket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(long Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TTicket> GetTickets()
        {
            return _context.Tickets.ProjectTo<TTicket>();
        }
    }
}
