using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace CRM.DAL.Entities
{
    public class Customer : IEntity
    {
        public long CreatedBy
        {
            get; set;         
        }
        DateTime? dateCreated;
        public DateTime DateCreated
        {
            get{
                return dateCreated ?? DateTime.Now;
            }
            set {
                dateCreated = value;
            }
            
        }

        public DateTime? DateModified
        {
            get;
            set;

            
        }

        public long CustomerId
        {
            get;
            set;
        }
        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        [Required]
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        [Required]
        public string PrimaryContact { get; set; }
        public string SecondaryContact { get; set; }
        [Required]
        public string CustomerType { get; set; }  //SUV for Super Vendor V for Vendor, C for Vendor's Customer 
        public long ParentId { get; set; }  //It is a CustId if there is no parent, CustId of Parent for childs (i.e. customers)
        [DefaultValue(0)]
        public int Status
        {
            get; set;
        }

        public virtual Country Country { get; set; }
       
    }

  
}
