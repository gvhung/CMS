using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.Business;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CRM.UI.ViewModels;
using PagedList;
using System.Text;

namespace CRM.UI.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Create(int? id)
        {

            TicketCreateModel ticketcreateModel = new TicketCreateModel();
            try
            {
                int ticketid = Convert.ToInt32(id);
                if (ticketid > 0)
                    ticketcreateModel = Edit(ticketid);
                ProductBiz productbiz = new ProductBiz();
                TicketBiz ticketbiz = new TicketBiz();
                // ViewBag.lstDropdown = ticketbiz.BindCompanies();
                ticketcreateModel.Products = productbiz.GetProducts(Convert.ToInt64(Session["CompanyId"]));
                ticketcreateModel.Priorities = ticketbiz.GetPriorities();
                ticketcreateModel.Seviorities = ticketbiz.GetSeviorities();
                ticketcreateModel.TicketTypes = ticketbiz.GetTicketTypes();
                // ticketcreateModel.lstproducts.Insert(0, new Product() { Id = 0, Name = "Select Product" });
                //ViewBag.lstComponents = productbiz.GetComponents();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CT", ex.Message);

            }

            return View(ticketcreateModel);
        }

        [HttpPost]
        public ActionResult Create(TicketCreateModel T)
        {
            Ticket ticket = new Ticket();
            TicketCreateModel ticketcreateModel = new TicketCreateModel();
            try
            {
                ticket.TicketNo = T.TicketNo;
                ticket.Description = T.Description;
                ticket.Title = T.Title;
                ticket.VersionId = T.VersionId;
                ticket.ProductId = T.ProductId;
                ticket.CompanyId = T.CompanyId;
                ticket.ComponentId = T.ComponentId;
                ticket.SeviorityId = T.SeviorityId;
                ticket.PriorityId = T.PriorityId;
                ticket.TicketTypeId = T.TicketTypeId;
                ticket.CompanyId = Convert.ToInt32(Session["CompanyId"]);
                ticket.CreatedBy = Convert.ToInt64(Session["UID"]);
                TicketBiz ticketbiz = new TicketBiz();
                ProductBiz productbiz = new ProductBiz();
                ticketcreateModel.Products = productbiz.GetProducts(Convert.ToInt64(Session["CompanyId"]));
                ticketcreateModel.Priorities = ticketbiz.GetPriorities();
                ticketcreateModel.Seviorities = ticketbiz.GetSeviorities();
                ticketcreateModel.TicketTypes = ticketbiz.GetTicketTypes();
                int i = ticketbiz.AddTicket(ticket);
                if (i > 0)
                {
                    ViewBag.Message = "Successfully Insereted";
                }
                else
                {
                    ViewBag.ErrorMessage = " Inseret Failed";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("IT", ex.Message);
            }
            return View(ticketcreateModel);

        }

        public ActionResult List(int page = 1)
        {
            try
            {
                string clientname = ""; int StartIndex = 1, EndIndex = 20;
                List<Ticket> lstTicket = new List<Ticket>();
                TicketBiz ticketbiz = new TicketBiz();
                lstTicket = ticketbiz.GetAllTicket(clientname, StartIndex, EndIndex);
                ViewBag.tickets = lstTicket.ToPagedList(page, 10);
                // List<TicketListModel> lstTicketListModel = new List<TicketListModel>();
                //lstTicket.ForEach(item => lstTicketListModel.Add(Mapper.Map<TicketListModel>(item)));
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("LI", Ex.Message);

            }
            return View();
        }

        public TicketCreateModel Edit(int id)
        {
            TicketBiz ticketbiz = new TicketBiz();
            Ticket t = ticketbiz.GetTicketById(id);
            //TicketCreateModel ticketcraetemodel= AutoMapper.Mapper.Map<TicketCreateModel>(t);
            TicketCreateModel ticketCreateModel = new TicketCreateModel();
            ProductBiz productbiz = new ProductBiz();
            ticketCreateModel.Products = productbiz.GetProducts(Convert.ToInt64(Session["CompanyId"]));
            ticketCreateModel.Priorities = ticketbiz.GetPriorities();
            ticketCreateModel.Seviorities = ticketbiz.GetSeviorities();
            ticketCreateModel.TicketTypes = ticketbiz.GetTicketTypes();
            ticketCreateModel.Title = t.Title;
            ticketCreateModel.TicketId = t.TicketId;
            ticketCreateModel.Description = t.Description;
            ticketCreateModel.CompanyId = t.CompanyId;
            ticketCreateModel.ComponentId = t.ComponentId;
            ticketCreateModel.ProductId = t.ProductId;
            ticketCreateModel.VersionId = t.VersionId;
            ticketCreateModel.PriorityId = t.PriorityId;
            ticketCreateModel.SeviorityId = t.SeviorityId;
            ticketCreateModel.TicketTypeId = t.TicketTypeId;
            ticketCreateModel.ComponentName = t.ComponentName;
            ticketCreateModel.CompanyName = t.CompanyName;
            ticketCreateModel.ProductName = t.ProductName;
            long Id = ticketCreateModel.ProductId;
            ticketCreateModel.Components = productbiz.GetComponent(Id);
            ticketCreateModel.Versions = productbiz.GetVersions(Id);

            return ticketCreateModel;
            // return View("Create", ticketCreateModel);
        }

        public ActionResult Delete(int id)
        {
            int ticketid = Convert.ToInt32(id);
            if (id < 0)
                return RedirectToAction("List");
            TicketBiz ticketBiz = new TicketBiz();
            int i = ticketBiz.DeleteTicket(id);
            if (i > 0)
            {
                ViewBag.Message = "Ticket Successfully Deleted";
            }
            else
            {
                ViewBag.ErrorMessage = "Ticket delate Failed";
            }
            return RedirectToAction("List");
        }

        public ActionResult BindDropDowns(string flag, long Id)
        {

            StringBuilder sbOptions = new StringBuilder();

            if (flag == "Components")
            {
                ProductBiz productbiz = new ProductBiz();
                var lstComponents = productbiz.GetComponent(Id);
                //var lstComponents = AllComponents.FindAll(c => c.ID == Id);
                foreach (var item in lstComponents)
                {
                    sbOptions.Append("<option value=" + item.ComponentId + ">" + item.ComponentName + "</option>");
                }
            }

            else if (flag == "Versions")
            {
                ProductBiz productbiz = new ProductBiz();
                var lstVersions = productbiz.GetVersions(Id);
                //lstComponents.FindAll(c => c.ID == Id);
                foreach (var item in lstVersions)
                {
                    sbOptions.Append("<option value=" + item.VersionId + ">" + item.VersionName + "</option>");
                }
            }

            return Content(sbOptions.ToString());

        }

    }
}