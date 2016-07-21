using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public interface ITicket
    {
        long TicketId { get; set; }
        long TicketNo { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        Int64 ProductId { get; set; }
        Int64 ComponentId { get; set; }
        long VersionId { get; set; }
        int Status { get; set; }
        long CompanyId { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        Int64 CreatedBy { get; set; }
        DateTime DateFixed { get; set; }
        DateTime DateClosed { get; set; }
        int TicketTypeId { get; set; }
        int SeviorityId { get; set; }
        int PriorityId { get; set; }
        bool Validate();
    }
}
