using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UI.Models
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