using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class ClientEditModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string TicketStartNumber { get; set; }
    }
}