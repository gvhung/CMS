using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Ticket : ITicket
    {
        public long Id { get; set; }
        public string Assignee { get; set; }
        public int ComponentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int BranchId { get; set; }
        public int ModuleId { get; set; }
        public int Priority { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TenantId { get; set; }
        public long? TicketNo { get; set; }
        public int TicketType { get; set; }
        public string Version { get; set; }
        public bool Validate()
        {
            if (Title == null || Title.Trim() == "") throw new Exception("Title is empty");
           if (ProductId == 0 ) throw new Exception("Inavlid product id");
            //if (CreatedBy == 0) throw new Exception("Invalid Ticket: Unauthenticated user");
            return true;
        }
    }
}
