using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tickets
{
    public interface ITicketStore<TTicket>
    {
        void CreateTicket(TTicket ticket);
    }


}
