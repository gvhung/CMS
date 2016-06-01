using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Tickets.Interfaces;
using CRM.Model;
namespace CRM.Store
{
    public class UnitOfWork:IDisposable
    {
        CRMContext _context;

        public UnitOfWork()
        {
            _context = new CRMContext("CRMContext");
        }

        public UnitOfWork(string constr)
        {
            _context = new CRMContext(constr);
        }
       ITicketStore<Ticket> _ticketStore;
       public ITicketStore<Ticket> TiketStore
        {
            get { 
                
                if (_ticketStore!=null) _ticketStore=new TicketStore<Ticket>(_context);

                return _ticketStore;
            }
            
        }
       private bool disposed = false;
        public virtual void Dispose(bool disposing)
       {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
       }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }
    }
}
