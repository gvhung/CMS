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
        public void CreateProduct(TProduct product)
        {
            ProductEntity productEntity = (ProductEntity)AutoMapper.Mapper.Map<ProductEntity>(product);
            _context.Products.Add(productEntity);
            _context.SaveChanges();
        }

       

        public IQueryable<TProduct> GetProducts(SearchCriteria criteria)
        {

            var res = from c in _context.Products
                      where c.Name == criteria.Title || String.IsNullOrEmpty(criteria.Title) /*criteria.Title==""*/
                      select c;
            return res.ProjectTo<TProduct>();
        }

        public Product GetProductByID(int id)
        {
            ProductEntity Productvalues = _context.Products.Find(id);
            var Product = (Product)AutoMapper.Mapper.Map<Product>(Productvalues);
            return Product;
        }




    }
}
