using CRM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
   public class Branch:IBranch
    {
        public string BracnhName { get; set; }
        public string BranchCode { get; set; }
        public long TicketStartNumber { get; set; }
        public int ClientId { get; set; }
        public bool Validate()
        {
            return true;
        }
    }
}
