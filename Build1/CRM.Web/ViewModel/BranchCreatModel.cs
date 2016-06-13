using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.ViewModel
{
    public class BranchCreatModel
    {
        public int BranchId { get; set; }
        [Display(Name = "Branch Name")]
        public string BracnhName { get; set; }
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        [Display(Name = "Ticket Start Number")]
        public long TicketStartNumber { get; set; }
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }
    }
}
