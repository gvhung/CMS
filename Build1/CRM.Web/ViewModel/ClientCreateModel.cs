using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class ClientCreateModel
    {
        public int ClientId { get; set; }
        [Display(Name ="Client Name")]
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConformPassword { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
    }
}