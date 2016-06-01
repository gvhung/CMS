using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Client : IClient
    {
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string TicketStartNumber { get; set; }
        public bool Validate()
        {
            return true;
        }
    }
}
