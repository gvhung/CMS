using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class TicketListModel
    {
        public long TicketId { get; set; }
        public long? TicketNo { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string Priority { get; set; }
        public string TicketType { get; set; }        
    }
}