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
            TicketBiz ticketbiz = new TicketBiz();
            ticketbiz.GetAllTicket();
            return View();
        }



        [HttpPost]
        public ActionResult Create(TicketCreateModel T)
        {
            Ticket ticket = new Ticket();
            ticket.Description = T.Description;
            ticket.Title = T.Title;
            ticket.TicketType = T.TicketType;
            ticket.Version=T.Version;
            ticket.Priority = T.SeverityCode;
            ticket.ModuleId = T.ModuleId;
            ticket.ProductId = T.ProductId;
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


    }
}