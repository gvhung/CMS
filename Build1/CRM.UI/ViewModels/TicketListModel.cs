using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.UI.ViewModels
{
    public class TicketListModel
    {
        [Display(Name = "Ticket No")]
        public Decimal TicketNo { get; set; }
        [Display(Name = "Company Name")]
        public int CompanyName { get; set; }
        [Display(Name = ("Product Name"))]
        public long ProductName { get; set; }
        [Display(Name = ("Component Name"))]
        public long ComponentName { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Assignee { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}