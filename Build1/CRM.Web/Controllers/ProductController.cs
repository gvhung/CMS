using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Web.ViewModel;
using CRM.Tickets;
using CRM.Store;
using CRM.Model;
using AutoMapper.QueryableExtensions;
using CRM.Business;
namespace CRM.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            ProductManager<Product> productManager = new ProductManager<Product>(new ProductStore<Product>());
            IQueryable<Product> products= productManager.GetProducts();

            IQueryable<ProductListModel> lstProductListModel = products.ProjectTo<ProductListModel>();

          
            return View(lstProductListModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCreateModel m)
        {
            Product p = AutoMapper.Mapper.Map<Product>(m);

            ProductBiz productBiz = new ProductBiz();
            productBiz.AddProduct(p);
            return View(m);
        }
    }
}