using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public interface ITicket
    {
         decimal TicketId { get; set; }
         decimal TicketNo { get; set; }
         string Title { get; set; }
         string Description { get; set; }
         Int64 ProductId { get; set; }
         Int64 ComponentId { get; set; }
         string Version { get; set; }
         int Status { get; set; }
         int CompanyId { get; set; }
         DateTime DateCreated { get; set; }
         DateTime DateModified { get; set; }
         Int64 CreatedBy { get; set; }
         DateTime DateFixed { get; set; }
         DateTime DateClosed { get; set; }
        bool Validate();
    }
}
