using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CRM.Model;

namespace CRM.Web.ViewModel
{
    public class ProductCreateModel
    {
     //   [Required]
     //   public string Client { get; set; }
        [Required]
        [Display(Name = "Company")]
        public string ClientId { get; set; }
        [Display(Name="Product Name")]
        public string Name { get; set; }

        public List<Client> Clients { get; set; }
        public string Description { get; set;}
        [Display(Name = "versions")]
        public string Versions { get; set; }
    }
}