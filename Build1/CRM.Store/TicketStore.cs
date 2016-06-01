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
using System.Data.Entity;
namespace CRM.Store
{
    public class TicketStore<TTicket> : ITicketStore<TTicket> where TTicket:ITicket
    {
        CRMContext _context;
        
        public TicketStore():this("CRMContext")
        {

        }
        public TicketStore(string constr)
        {
            _context = new CRMContext(constr);
        }

        public TicketStore(CRMContext context)
        {
            _context = context;
        }
        public void CreateTicket(TTicket ticket)
        {
          
            TicketEntity ticketEntity=(TicketEntity) AutoMapper.Mapper.Map<TicketEntity>(ticket);
            _context.Tickets.Add(ticketEntity);
            
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
            //var q = (from T in _context.Tickets
                     
            //         select new
            //         {
            //             T.TickeId,
            //             T.TicketNo,
            //             T.TicketType,
            //             T.Priority,
            //             T.Title,
            //        }) as IQueryable<TTicket>;
            //return q;

        }

      

        public IQueryable<TTicket>  GetTickets(SearchCriteria criteria)
        {
            var res = from t in _context.Tickets
                      where t.Title ==criteria.Title ||   String.IsNullOrEmpty(criteria.Title)
                      select t;
            return res.ProjectTo<TTicket>();
        }
    }
}
