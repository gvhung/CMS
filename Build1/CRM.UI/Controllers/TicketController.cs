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

namespace CRM.UI.Controllers
{

    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Create()
        {
            TicketBiz ticketbiz = new TicketBiz();
            ViewBag.lstDropdown = ticketbiz.BindCompanies();
            ViewBag.lstProducts= ticketbiz.BindProducts();
            ViewBag.lstComponents = ticketbiz.BindComponent();

            return View();
        }

        [HttpPost]
        public ActionResult Create(TicketCreateModel T)
        {
            Ticket ticket = new Ticket();
            ticket.TicketNo = T.TicketNo;
            ticket.Description = T.Description;
            ticket.Title = T.Title;
            ticket.Version = T.Version;
            ticket.ProductId = T.ProductId;
            ticket.CompanyId = T.CompanyId;
            ticket.ComponentId = T.ComponentId;
            ticket.CreatedBy = Convert.ToInt64(Session["UID"]);
            TicketBiz ticketbiz = new TicketBiz();
            int i = ticketbiz.AddTicket(ticket);
            if (i > 0)
            {
                ViewBag.Message = "Successfully Insereted";
            }
            else
            {
                ViewBag.ErrorMessage = " Inseret Failed";
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult List()
        //{
        //    List<Ticket> lstTicket = new List<Ticket>();
        //    TicketBiz ticketbiz = new TicketBiz();
        //    lstTicket = ticketbiz.GetAllTicket();
        //    ViewBag.tickets = lstTicket;
        //    return View();
        //}

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
        public ActionResult GetTicketById(int id)
        {
            TicketBiz ticketbiz = new TicketBiz();
            Ticket t = ticketbiz.GetTicketById(id);
            //TicketCreateModel ticketcraetemodel= AutoMapper.Mapper.Map<TicketCreateModel>(t);
            TicketCreateModel ticketcreatemodel = new TicketCreateModel();
            ticketcreatemodel.Title = t.Title;
            ticketcreatemodel.Description = t.Description;
            //ticketcreatemodel.ModuleId = t.ModuleId;
            //ticketcreatemodel.SeverityCode = t.Priority;
            //ticketcreatemodel.TicketType = t.TicketType;
            ticketcreatemodel.Version = t.Version;
            return View("Create", ticketcreatemodel);
        }

        [HttpPost]
        public ActionResult UpdateTicket()
        {
            return View();
        }

    }
}