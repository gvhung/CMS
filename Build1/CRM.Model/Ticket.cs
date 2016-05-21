using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
   public class Ticket : ITicket
    {
        public string Assignee { get; set; }

        public int ComponentId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateClosed { get; set; }
        
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
        
        public long Id { get; set; }
        
        public int ModuleId { get; set; }
        
        public int Priority { get; set; }
        public int ProductId { get; set; }

        public string Reason { get; set; }
        public int TenantId { get; set; }

        public long? TicketNo { get; set; }
        public int TicketType { get; set; }

        public string Version { get; set; }
        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
