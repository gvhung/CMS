using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.Web.ViewModel;
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


            ClientManager<Client> clientManager =new ClientManager<Client> (new ClientStore<Client>());
            clientManager.CreateClient(client);

            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult List(string Search, int page=1)
        {
           SearchCriteria criteria = new SearchCriteria();
            criteria.Title = Search;
            ClientManager<Client> clientManager = new ClientManager<Client>(new ClientStore<Client>());
           
            IQueryable<Client> lstClients = clientManager.GetClient(criteria);
            IQueryable<ClientListModel> lstClientListModel = lstClients.ProjectTo<ClientListModel>().OrderBy(c => c.Name); 
            IPagedList<ClientListModel> pagedList = lstClientListModel.ToPagedList(page,6);
            return View(pagedList);
        }



        public ActionResult Edit(int id)
        {
            ClientManager<Client> clientManager = new ClientManager<Client>(new ClientStore<Client>());

            Client c = clientManager.GetClientByID(id);
            ClientEditModel ClientModel = (ClientEditModel)AutoMapper.Mapper.Map<ClientEditModel>(c);

            return View("EditClient", ClientModel);
        }




    }
}