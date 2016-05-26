using CRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Store;
using CRM.Tickets;
using CRM.Model;

namespace CRM.Web.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /CreatTicket/




        public ActionResult Create()
        {

            TicketCreateModel model = new TicketCreateModel();
            model.Modules = new List<Module>();
            model.Modules.Add(new Module() { Id = 1, Name = "Tickets" });
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
        [HttpPost]
        public ActionResult Create(TicketCreateModel m)
        {
            CRM.Model.Ticket ticket = new Model.Ticket();
            ticket.Title = m.Title;
            ticket.BranchId = 1;

            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new TicketStore<Ticket>(new CRMContext("CRMContext")));
            ticketManager.CreateTicket(ticket);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            List<TicketListModel> lst = new List<TicketListModel>();
            TicketListModel obj = new TicketListModel();
            obj.Id = 02;
            obj.IssueType = "Error";
            obj.ModuleId = "001";
            obj.ProductId = "002";
            obj.SeverityCode = "003";
            obj.Title = "TicketIssue";
            obj.Version = "xyz";
            obj.Description = "jkhdasjdkssd";
            obj.DueDate = "05/17/2016";
            ViewBag.data = obj;
            lst.Add(obj);
            return View(lst.AsEnumerable());
        }

        public ActionResult Detail()
        {
            TicketDetailModel obj = new TicketDetailModel();
            obj.Id = 02;
            obj.IssueType = "Error";
            obj.ModuleId = "001";
            obj.ProductId = "002";
            obj.SeverityCode = "003";
            obj.Title = "TicketIssue";
            obj.Version = "xyz";
            obj.Description = "jkhdasjdkssd";
            obj.DueDate = "05/17/2016";
            //  ViewBag.data = obj;

            return View(obj);
        }

    }
}
