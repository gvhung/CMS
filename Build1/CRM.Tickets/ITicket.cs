﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tickets
{
    public interface ITicket<TKey>
    {
        TKey Id { get; set; }
        long TicketNo { get; set; }
        int Priority { get; set; }
        string Reason { get; set; }
        int ProductId { get; set; }
        int ModuleId { get; set; }
        int ComponentId { get; set; }
        string Version { get; set; }

        string Assignee { get; set; }
        int CreatedBy { get; set; }
        int TicketType  { get; set; }
        int TenantId { get; set; }
        DateTime DateClosed { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        bool Validate();
    }
}
