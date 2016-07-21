using CRM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Store;
using CRM.Tickets;
using PagedList;
using AutoMapper.QueryableExtensions;
using CRM.Model;

namespace CRM.Web.Controllers
{
    public class TicketController : Controller
    {
        // GET: /CreatTicket/
        public ActionResult Create()
        {
            ProductStore<Product> productStore = new ProductStore<Product>();

            TicketCreateModel model = new TicketCreateModel();
            model.Modules = new List<Module>();
            model.Modules.Add(new Module() { Id = 1, Name = "Tickets" });
            model.Modules.Add(new Module() { Id = 2, Name = "Contacts" });
            model.Modules.Add(new Module() { Id = 3, Name = "Invoices" });

            ProductManager<Product> productManager = new ProductManager<Product>(productStore);

            model.Products = productManager.GetAllProducts();
            model.Products.Insert(0, new Product() { Id = 0, Name = "Select Product" });
          

            //TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new TicketStore<Ticket>());
            //model.Products = new List<Product>();

            //model.Products=ticketManager.GetProduct();

            model.Priorities = new List<Priority>();
            model.Priorities.Add(new Priority() { Code = 1, Name = "High" });
            model.Priorities.Add(new Priority() { Code = 2, Name = "Medium" });
            model.Priorities.Add(new Priority() { Code = 3, Name = "Low" });
            model.Priorities.Add(new Priority() { Code = 1, Name = "Critical" });
            model.Priorities.Add(new Priority() { Code = 1, Name = "Blocker" });

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TicketCreateModel m)
        {
            CRM.Model.Ticket ticket = new Model.Ticket();
            ticket.Title = m.Title;
            //ticket.BranchId = 3;
            ticket.Description = m.Description;
            //ticket.Priority = m.SeverityCode;
            //ticket.TicketType = m.TicketType;
            //ticket.ModuleId = m.ModuleId;
            ticket.ProductId = m.ProductId;
            ticket.VersionId = m.VersionId;
            
            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new TicketStore<Ticket>());
            ticketManager.CreateTicket(ticket);
            return RedirectToAction("List");
        }

        public ActionResult List(string Search, int page = 1)
        {
            SearchCriteria criteria = new SearchCriteria();
            criteria.Title = Search;
            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new TicketStore<Ticket>());
            //List<TicketListModel> lst = new List<TicketListModel>();
            //ticketManager.GetTickets().ForEach(t => lst.Add(new TicketListModel() { TicketNo = t.TicketNo == null ? 0:Convert.ToUInt32(t.TicketNo), TicketType = Convert.ToString(t.TicketType), Priority = Convert.ToString(t.Priority),Title=t.Title }));
            IQueryable<Ticket> lstTickets = ticketManager.GetTickets(criteria);
            IQueryable<TicketListModel> lstTicketListModel = lstTickets.ProjectTo<TicketListModel>().OrderBy(t => t.TicketNo);
            IPagedList<TicketListModel> pagedList = lstTicketListModel.ToPagedList(page, 5);

            return View(pagedList);
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
