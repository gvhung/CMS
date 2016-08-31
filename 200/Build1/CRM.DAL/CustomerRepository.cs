using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CRM.DAL.Entities;
using CRM.DAL.Interfaces;

namespace CRM.DAL
{


    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        
        public CustomerRepository(IRepositoryContext context):base(context)
        {

        }
        public Customer GetCustomerById(long custId)
        {
           return Context.GetEntities<Customer>().FirstOrDefault(c => c.CustomerId == custId);
        }
        
    }
}
