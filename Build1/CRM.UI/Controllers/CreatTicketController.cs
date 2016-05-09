using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class CreatTicketController : Controller
    {
        //
        // GET: /CreatTicket/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            TicketViewModel model = new TicketViewModel();
            model.Modules = new List<Module>();
            model.Modules.Add(new Module() { Id = 1,Name= "Tickets" });
            model.Modules.Add(new Module() { Id = 2, Name = "Contacts" });
            model.Modules.Add(new Module() { Id = 3, Name = "Invoices" });


            model.Products = new List<Product>();
            model.Products.Add(new Product() { Id = 1, Name = "CRM" });


            model.Severities = new List<Severity>();
            model.Severities.Add(new Severity() { Code = 1, Name = "High" });
            model.Severities.Add(new Severity() { Code = 2, Name = "Medium" });
            model.Severities.Add(new Severity() { Code = 3, Name = "Low" });
            model.Severities.Add(new Severity() { Code = 1, Name = "Critical" });
            model.Severities.Add(new Severity() { Code = 1, Name = "Blocker" });


            
            
            return View(model);
        }

    }
}
