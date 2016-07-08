using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.UI.ViewModels;
using CRM.Business;
using CRM.Model;
namespace CRM.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            List<ProductListVM> lst = new List<ProductListVM>();
            ProductBiz productBiz = new ProductBiz();
            List<Product> lstProducts = productBiz.GetProducts(1,10,"");
            for(int i=0;i<lstProducts.Count; i++)
            {
                ProductListVM t = new ProductListVM();
                t.ProductId = lstProducts[i].Id.ToString();
                t.ProductName = lstProducts[i].Name;
                t.CompanyName = lstProducts[i].CompanyName;
                t.Version = lstProducts[i].Versions;

                lst.Add(t);
            }


            return View(lst);
        }

        public ActionResult Edit(int id)
        {

            ProductEditVM m = new ProductEditVM();
            ProductBiz productBiz = new ProductBiz();
            Product p = productBiz.GetProductInfo(id);
            m.ProductName = p.Name; // should get from databse;
            m.Versions =p.Versions; // get from databse;
            m.CompanyId =p.CompanyId; // get from databse
            
            m.Companies= productBiz.GetCompanies(); // getting from database
            

           
            return View(m);            
        }
        
    }
}