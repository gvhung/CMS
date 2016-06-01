using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.Web.Models;
using CRM.Tickets;
using CRM.Store;
using AutoMapper.QueryableExtensions;
using PagedList;

namespace CRM.Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientCreateModel m)
        {
            Client client = new Client();
            client.Name = m.Name;
            client.TicketStartNumber = m.TicketStartNumber;


            ClientManager<Client> clientManager = new ClientManager<Client>(new ClientStore<Client>());
            clientManager.CreateClient(client);

            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult List()
        {
           // SearchCriteria criteria = new SearchCriteria();
           // criteria.Title = Search;
            ClientManager<Client> clientManager = new ClientManager<Client>
                (new ClientStore<Client>());
            //List<TicketListModel> lst = new List<TicketListModel>();
            //ticketManager.GetTickets().ForEach(t => lst.Add(new TicketListModel() { TicketNo = t.TicketNo == null ? 0:Convert.ToUInt32(t.TicketNo), TicketType = Convert.ToString(t.TicketType), Priority = Convert.ToString(t.Priority),Title=t.Title }));
            IQueryable<Client> lstClients = clientManager.GetClient();
            IQueryable<ClientListModel> lstClientListModel = lstClients.ProjectTo<ClientListModel>();
           // IPagedList<ClientListModel> pagedList = lstClientListModel.ToPagedList(page, 2);
            return View(lstClientListModel);
        }




    }
}