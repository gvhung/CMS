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
    public class CompanyController : Controller
    {
        // GET: Client
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CompanyCreateModel m)

        {
            try
            {

                Company client = new Company();
                client.Name = m.Name;
                // client.TicketStartNumber = Convert.ToInt32(m.TicketStartNumber);

                CRMUser user = new CRMUser() { Username = m.EmailId, Password = m.Password };

                CompanyManager<Company> clientManager = new CompanyManager<Company>(new CompanyStore<Company>());
                clientManager.CreateClient<CRMUser>(client, user);

                return View("RegisterSuccess");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CC", ex.Message);
                return View(m);
            }

        }

        [HttpGet]
        public ActionResult List(string Search, int page = 1)
        {
            SearchCriteria criteria = new SearchCriteria();
            criteria.Title = Search;
            CompanyManager<Company> clientManager = new CompanyManager<Company>(new CompanyStore<Company>());
            IQueryable<Company> lstClients = clientManager.GetClient(criteria);
            IQueryable<ClientListModel> lstClientListModel = lstClients.ProjectTo<ClientListModel>().OrderBy(c => c.Name);
            IPagedList<ClientListModel> pagedList = lstClientListModel.ToPagedList(page, 6);
            return View(pagedList);
        }

        public ActionResult Edit(int id)
        {
            CompanyManager<Company> clientManager = new CompanyManager<Company>(new CompanyStore<Company>());

            Company c = clientManager.GetClientByID(id);
            ClientEditModel ClientModel = (ClientEditModel)AutoMapper.Mapper.Map<ClientEditModel>(c);

            return View("Edit", ClientModel);
        }

        [HttpPost]
        public ActionResult Edit(ClientEditModel m)
        {
            CompanyManager<Company> clientManager = new CompanyManager<Company>(new CompanyStore<Company>());
            Company c = AutoMapper.Mapper.Map<Company>(m);
            clientManager.UpdateClient(c);
            return View(m);
        }


    }
}