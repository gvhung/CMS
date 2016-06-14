using CRM.Model.Interfaces;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRM.Model;

namespace CRM.Tickets
{

    public class ProductManager<TProduct> where TProduct:IProduct
    {
        IProductStore<TProduct> _productStore;
        public ProductManager(IProductStore<TProduct> productStore)
        {
            _productStore = productStore;
        }
        public void CreateProduct(TProduct product)
        {

            if (product.Validate())
            {
                _productStore.CreateProduct(product);
                //send email to client

            }
        }
        public List<TProduct> GetAllProducts()
        {
            return _productStore.GetProducts(new SearchCriteria() { Title = "" }).ToList();
        }
        public IQueryable<TProduct> GetProducts(SearchCriteria criteria)
        {


            return _productStore.GetProducts(criteria);
        }
        //public List<TProduct> GetAllProducts()
        //{
        //    SearchCriteria crieteria = new SearchCriteria();

        //    return _productStore.GetProducts(crieteria).ToList();
        //}
        public Product GetProductByID(int id)
        {
            return _productStore.GetProductByID(id);
        }

      
    }
}
