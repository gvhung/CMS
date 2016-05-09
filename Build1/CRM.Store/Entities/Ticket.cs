using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
namespace CRM.Store.Entities
{
    public class TicketEntity
    {
        public Guid Id { get; set; }
        public long TicketNo { get; set; }
    }
}
