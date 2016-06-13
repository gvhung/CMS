using CRM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;

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
                           
            return View();
        }

    }

}