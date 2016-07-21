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

        public List<Product> GetProducts(long companyId)
        {
            ProductDB productDB = new ProductDB();
            List<Product> lstProducts = new List<Product>();
            lstProducts = productDB.GetProducts(companyId);
            return lstProducts;
        }
        public List<Component> GetComponent(long productId)
        {
            ProductDB productDB = new ProductDB();
            List<Component> lstComponents = new List<Component>();
            return lstComponents = productDB.GetComponents(productId);
        }

        public List<ProductVersion> GetVersions(long productId)
        {
            ProductDB productDB = new ProductDB();
            List<ProductVersion> lstversions = new List<ProductVersion>();
            return lstversions = productDB.GetVersions(productId);
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
        public void UpdateProduct(long productid, string OldVersion, string version, string OldComponents, string Components)
        {

            if (productid == 0)
                throw new Exception("No Product is found");
            ProductDB productDB = new ProductDB();
            productDB.UpdateProduct(productid, OldVersion, version, OldComponents, Components);

        }


        public void CreateProduct(Product product)
        {
            ProductDB productDB = new ProductDB();
           // Component componentDB = new Component();
            productDB.CreateProduct(product);  
        }


    }
}
