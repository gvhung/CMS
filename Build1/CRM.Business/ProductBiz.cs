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
        public void DeleteProduct(long productId)
        {
            if (productId == 0)
                throw new Exception("No Product is found");
            ProductDB productdb = new ProductDB();
            productdb.DeleteProduct(productId);
        }
        public List<Company> GetCompanies()
        {
            ProductDB productDB = new ProductDB();
            return productDB.GetCompanies();
        }
        public void UpdateProduct(long productid, string OldVersion, string version)
        {

            if (productid == 0)
                throw new Exception("No Product is found");
            ProductDB productDB = new ProductDB();
            productDB.UpdateProduct(productid, OldVersion, version);

        }


        public void CreateProduct(Product product)
        {
            ProductDB productDB = new ProductDB();
            productDB.CreateProduct(product);
        }
    }
}
