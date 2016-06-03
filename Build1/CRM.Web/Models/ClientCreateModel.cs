using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class ClientCreateModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        [Display(Name="Ticket Start Number")]
        public string TicketStartNumber { get; set; }
    }
}