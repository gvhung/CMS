using CRM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.Business;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            ticket.Description = T.Description;
            ticket.Title = T.Title;
            ticket.Version=T.Version;
            ticket.ProductId = T.ProductId;
            ticket.TicketNo = T.TicketNo;
            ticket.CompanyId = T.CompanyId;
            ticket.ComponentId = T.ComponentId;
            TicketBiz ticketbiz = new TicketBiz();
            ticketbiz.AddTicket(ticket);
            return View();
        }

        [HttpGet]
        public ActionResult GetAllTickets()
        {
            List<Ticket> lstTicket = new List<Ticket>();
            TicketBiz ticketbiz = new TicketBiz();
            lstTicket= ticketbiz.GetAllTicket();

            List<TicketListModel> lstTicketListModel = new List<TicketListModel>();
            lstTicket.ForEach(item => lstTicketListModel.Add(Mapper.Map<TicketListModel>(item)));

            return View(lstTicketListModel);

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