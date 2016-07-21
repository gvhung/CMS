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
        public ActionResult Create()
        {
            TicketCreateModel ticketcreateModel = new TicketCreateModel();
            ProductBiz productbiz = new ProductBiz();
            TicketBiz ticketbiz = new TicketBiz();
            // ViewBag.lstDropdown = ticketbiz.BindCompanies();
            ticketcreateModel.Products = productbiz.GetProducts( Convert.ToInt64( Session["CompanyId"]));
            ticketcreateModel.Priorities = ticketbiz.GetPriorities();
            ticketcreateModel.Seviorities = ticketbiz.GetSeviorities();
            ticketcreateModel.TicketTypes = ticketbiz.GetTicketTypes();
            
            // ticketcreateModel.lstproducts.Insert(0, new Product() { Id = 0, Name = "Select Product" });
            //ViewBag.lstComponents = productbiz.GetComponents();

            return View(ticketcreateModel);
        }

        [HttpPost]
        public ActionResult Create(TicketCreateModel T)
        {
            Ticket ticket = new Ticket();
            ticket.TicketNo = T.TicketNo;
            ticket.Description = T.Description;
            ticket.Title = T.Title;
            ticket.VersionId = T.VersionId;
            ticket.ProductId = T.ProductId;
            ticket.CompanyId = T.CompanyId;
            ticket.ComponentId = T.ComponentId;
            ticket.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            ticket.CreatedBy = Convert.ToInt64(Session["UID"]);
            TicketBiz ticketbiz = new TicketBiz();
            TicketCreateModel ticketcreateModel = new TicketCreateModel();
            ProductBiz productbiz = new ProductBiz();
            ticketcreateModel.Products = productbiz.GetProducts(Convert.ToInt64(Session["CompanyId"]));
            ticketcreateModel.Priorities = ticketbiz.GetPriorities();
            ticketcreateModel.Seviorities = ticketbiz.GetSeviorities();
            ticketcreateModel.TicketTypes = ticketbiz.GetTicketTypes();
            //ViewBag.lstDropdown = ticketbiz.BindCompanies();
            //ViewBag.lstProducts = ticketbiz.BindProducts();
            //ViewBag.lstComponents = ticketbiz.BindComponent();
            int i = ticketbiz.AddTicket(ticket);
            if (i > 0)
            {
                ViewBag.Message = "Successfully Insereted";
            }
            else
            {
                ViewBag.ErrorMessage = " Inseret Failed";
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
                ViewBag.tickets = lstTicket.ToPagedList(page, 5);
                // List<TicketListModel> lstTicketListModel = new List<TicketListModel>();
                //lstTicket.ForEach(item => lstTicketListModel.Add(Mapper.Map<TicketListModel>(item)));
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("LI", Ex.Message);

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            TicketBiz ticketbiz = new TicketBiz();
            Ticket t = ticketbiz.GetTicketById(id);
            //TicketCreateModel ticketcraetemodel= AutoMapper.Mapper.Map<TicketCreateModel>(t);
            TicketCreateModel ticketcreatemodel = new TicketCreateModel();
            ticketcreatemodel.Title = t.Title;
            ticketcreatemodel.Description = t.Description;
            ticketcreatemodel.CompanyId = t.CompanyId;
            ticketcreatemodel.ComponentId = t.ComponentId;
            ticketcreatemodel.ProductId = t.ProductId;
            ticketcreatemodel.VersionId = t.VersionId;
            ticketcreatemodel.ComponentName = t.ComponentName;
            ticketcreatemodel.CompanyName = t.CompanyName;
            ticketcreatemodel.ProductName = t.ProductName;

            //ticketcreatemodel.lstModel = ticketbiz.BindCompanies();
            //ViewBag.lstDropdown = ticketcreatemodel.lstModel;
            //ViewBag.lstProducts = ticketbiz.BindProducts();
            //ViewBag.lstComponents = ticketbiz.BindComponent();

            return View("Create", ticketcreatemodel);
        }

        [HttpPost]
        public ActionResult UpdateTicket()
        {
            return View();
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