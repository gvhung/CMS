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
using PagedList;
namespace CRM.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult create()
        {
            CompanyStore<Company> clientStore = new CompanyStore<Company>();
            CompanyManager<Company> clientManager = new CompanyManager<Company>(clientStore);
            ProductCreateModel m = new ProductCreateModel();
            m.Clients=clientManager.GetAllClients();
            m.Clients.Insert(0, new Company() { CompanyId = 0, Name = "Select Company" });
            m.ClientId = "1";

     //    ClientManager< TClient > clientManager = new ClientManager<TClient>();

            return View(m);
        }

        [HttpPost]
        
        public ActionResult Create(ProductCreateModel m)
        {
            Product product = new Product();

           product.Name = m.Name;
            product.Description = m.Description;
            product.Versions = m.Versions;
            ProductManager<Product> productManager = new ProductManager<Product>(new ProductStore<Product>());
            productManager.CreateProduct(product);

            return RedirectToAction("List");

        }



        public ActionResult List(string Search,int page = 1)
        {
            SearchCriteria criteria = new SearchCriteria();
            criteria.Title = Search;
            ProductManager<Product> productManager = new ProductManager<Product>(new ProductStore<Product>());
            IQueryable<Product> products= productManager.GetProducts(criteria);

            IQueryable<ProductListModel> lstProductListModel = products.ProjectTo<ProductListModel>().OrderBy(p=>p.Name);
            IPagedList<ProductListModel> pagedList = lstProductListModel.ToPagedList(page, 5);

            return View(pagedList);
        }


        public ActionResult Edit(int id)
        {
            ProductManager<Product> productManager = new ProductManager<Product>(new ProductStore<Product>());

            Product p = productManager.GetProductByID(id);
            ProductEditModel ProductModel =AutoMapper.Mapper.Map<ProductEditModel>(p);

            return View(ProductModel);
        }



        public ActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create1(ProductCreateModel m)
        {
            Product p = AutoMapper.Mapper.Map<Product>(m);

            ProductBiz productBiz = new ProductBiz();
            productBiz.AddProduct(p);
            return View(m);
        }
    }
}