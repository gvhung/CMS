using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRM.Web.ViewModel
{
    public class ClientEditModel
    {
        [Display(Name="Client ID")]
        public int ClientId { get; set; }
        public string Name { get; set; }

        [Display(Name= "Ticket Start Number")]
        public long TicketStartNumber { get; set; }
    }
}