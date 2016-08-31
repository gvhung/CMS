using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Model
{
    //This is for both Edit and Detail
    public class CustomerViewModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }   //
        public string CustomerAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PrimaryContact { get; set; }
        public string SecondaryContact { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public long ParentId { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public long StatuCode { get; set; }
        public string PrimaryEmail { get; set; }
        public string CustomerType { get; set; }
         
    }

    public class CustomerListViewModel
    {
        public List<CustomerViewModel> CustomersList { get; set; }  //current page customers
        public long CurrentPage { get; set; }
        public long TotalCustomersCount { get; set; }
        public int PageSize { get; set; }

    }

    
}
