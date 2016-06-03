using CRM.Model.Interfaces;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tickets
{
   public class ProductManager<TProduct> where TProduct:IProduct
    {
        IProductStore<TProduct> _productStore;
        public ProductManager(IProductStore<TProduct> productStore)
        {
            _productStore = productStore;
        }
        public IQueryable<TProduct> GetProducts()
        {


            return _productStore.GetProducts();
        }
    }
}
