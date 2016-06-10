using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRM.Web.ViewModel
{
    public class ProductCreateModel
    {
        [Required]
        [Display(Name="Product Name")]
        public string Name { get; set; }

        public string Description { get; set;}
    }
}