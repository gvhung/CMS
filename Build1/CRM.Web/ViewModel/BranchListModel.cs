using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class BranchListModel
    {
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