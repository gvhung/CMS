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
using CRM.Model.Interfaces;

namespace CRM.Store
{
    public class ProductStore<TProduct> : IProductStore<TProduct> where TProduct: IProduct
    {
        CRMContext _context;
        public ProductStore():this("CRMContext")
        {

        }
        public ProductStore(string constr)
        {
            _context = new CRMContext(constr);
        }


        public IQueryable<TProduct> GetProducts()
        {
            return _context.Products.ProjectTo<TProduct>();
        }
    }
}
