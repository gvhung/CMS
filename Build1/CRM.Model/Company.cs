using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Company : ICompany
    {
        public int ClientId{get;set;}

        public string Name{get;set;}

        public DateTime DateCreated { get; set; }
        public long TicketStartNumber { get; set; }
        public bool Validate()
        {
            if (Name == null) throw new Exception("Name is Emty");
            //if (TicketStartNumber == null) throw new Exception("Ticket Start Number is Empty");
            return true;
        }

        
    }
}
