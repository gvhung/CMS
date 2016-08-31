using CRM.DAL.Entities;
using CRM.DAL.Interfaces;
using CRM.Core.Model;
using CRM.Core.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
namespace CRM.Core
{
    public class CustomerManager:ICustomerManager
    {
        IUnitOfWork _uow;
        public CustomerManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(CustomerViewModel customerViewModel)
        {
            //check if customer exists
           IList<Customer> lst= _uow.CustomerRepository.GetAll(
               c => (c.CustomerName == customerViewModel.CustomerName &&
                c.ParentId == customerViewModel.ParentId) );
            if (lst == null|| lst.Count==0)
            {
                Customer cust = AutoMapper.Mapper.Map<CustomerViewModel, Customer>(customerViewModel);
               _uow.CustomerRepository.Add(cust);
                _uow.SaveChanges();
            }
            else
                throw new Exception("Customer is already exists");
        }

        public List<CustomerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerListViewModel GetCustomers(int page, int pagesize, string customerName, string vendorName)
        { 

            IQueryable<Customer> query =_uow.CustomerRepository.GetQueryable();
            var qry = from c in query join v in query on c.ParentId equals v.CustomerId 
                      where c.CustomerName.Contains(customerName) && v.CustomerName == vendorName
                      select c;

                     
            
            CustomerListViewModel m = new CustomerListViewModel();
            m.CurrentPage = page;
            m.PageSize = pagesize;
            m.TotalCustomersCount = query.Count();
            var q = qry.Skip((page - 1) * pagesize).Take(pagesize).Select(cust => new CustomerViewModel() { CustomerId = cust.CustomerId, CustomerName = cust.CustomerName });
            m.CustomersList = q.ToList();
            return m;


        }

        public void Remove(CustomerViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
