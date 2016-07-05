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

namespace CRM.UI.Controllers
{
   
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Create()
        {
            //TicketBiz ticketbiz = new TicketBiz();
            //ticketbiz.GetAllTicket();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(TicketCreateModel T)
        {
            Ticket ticket = new Ticket();
            ticket.TicketNo = T.TicketNo;
            ticket.Description = T.Description;
            ticket.Title = T.Title;
            ticket.Version=T.Version;
            ticket.ProductId = T.ProductId;
            ticket.CompanyId = T.CompanyId;
            ticket.ComponentId = T.ComponentId;
            ticket.CreatedBy = Convert.ToInt64(Session["UID"]);
            TicketBiz ticketbiz = new TicketBiz();
            ticketbiz.AddTicket(ticket);
            return View();
        }
        [HttpGet]
        public ActionResult GetAllTickets()
        {
            List<Ticket> lstTicket = new List<Ticket>();
            TicketBiz ticketbiz = new TicketBiz();
            lstTicket = ticketbiz.GetAllTicket();
            ViewBag.tickets = lstTicket;
            return View();
        }
        [HttpPost]
        public ActionResult GetAllTickets(FormCollection form)
        {
            string clientname = form["SearchClientName"];
            int StartIndex = Convert.ToInt32(form["StartIndex"]);
            int EndIndex =   Convert.ToInt32(form["EndIndex"]);
            List<Ticket> lstTicket = new List<Ticket>();
            TicketBiz ticketbiz = new TicketBiz();
            lstTicket= ticketbiz.GetAllTicket(clientname, StartIndex, EndIndex);
            ViewBag.tickets = lstTicket;
           // List<TicketListModel> lstTicketListModel = new List<TicketListModel>();
            //lstTicket.ForEach(item => lstTicketListModel.Add(Mapper.Map<TicketListModel>(item)));

            return View();

        }

        [HttpGet]
        public ActionResult GetTicketById(int id)
        {
            TicketBiz ticketbiz = new TicketBiz();
           Ticket t= ticketbiz.GetTicketById(id);
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