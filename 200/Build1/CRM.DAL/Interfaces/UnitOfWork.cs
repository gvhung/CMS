using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        IRepositoryContext _context;
        public UnitOfWork(IRepositoryContext context)
        {
            _context = context;
        }
        ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null) _customerRepository = new CustomerRepository(_context);
                return _customerRepository;
            }
        }
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder str = new StringBuilder("");
                foreach (var eve in e.EntityValidationErrors)
                {
                    str.AppendLine(String.Format("Entity of {0} is in state {1}", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        str.AppendLine(String.Format("{0} - {1}", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                throw new Exception(str.ToString());
            }
        }
    }
}
