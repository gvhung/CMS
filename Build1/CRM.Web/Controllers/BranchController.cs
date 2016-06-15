using CRM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.Tickets;
using CRM.Store;

namespace CRM.Web.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BranchCreatModel b)
        {
           Branch branch = new Branch();
            branch.BracnhName = b.BracnhName;
            branch.BranchCode = b.BranchCode;
            branch.TicketStartNumber = b.TicketStartNumber;
            branch.ClientId = b.ClientId;

            BranchManager<Branch> branchManager = new BranchManager<Branch>(new BranchStore<Branch>());
            branchManager.CreateBranch(branch);                
            return View();
        }

    }

}