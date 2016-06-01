using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class ClientCreateModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string TicketStartNumber { get; set; }
    }
}