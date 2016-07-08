using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Dal;

namespace CRM.Business
{
    public class ProductBiz
    {
        public void AddProduct(Product p)
        {
            if (p.Validate())
            {
                ProductDB productDB = new ProductDB();
                productDB.AddProduct(p);
            }
        }
        public List<Product> GetProducts(long startIndex, long endIndex, string productName)
        {
            ProductDB productDB = new ProductDB();
            return productDB.GetProducts(startIndex, endIndex, productName);
           
        }
        public Product GetProductInfo(int productId)
        {
            if (productId == 0)
                throw new Exception("No product found");
            ProductDB productDb = new ProductDB();
           return productDb.GetProductInfo(productId);

        }
        public List<Company> GetCompanies()
        {
            ProductDB productDB = new ProductDB();
            return productDB.GetCompanies();
        }
        
    }
}
