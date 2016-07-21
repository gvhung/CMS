using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Model;
using System.ComponentModel.DataAnnotations;
namespace CRM.UI.ViewModels
{
    public class ProductListVM
    {
        public string ProductName { get; set; }
        public string Version { get; set; }
        public string CompanyName { get; set; }
        public string ProductId { get; set; }
        public long VersionId { get; set; }
        public string Components { get; set; }

    }

    public class ProductEditVM
    {
        public string ProductName { get; set; }
        public string Versions { get; set; }
        public string OldVersion { get; set; }
        public long ProductId { get; set; }
        public string Components { get; set; }
        public string OldComponents { get; set; }

        public ProductEditVM()
        {
        }

    }
   
    public class CreateNewProductVM
    {
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Versions { get; set; }
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        public List<Company> Compaines { get; set; }
        public long CompanyId { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Components ")]
        public string Components{ get; set; }


    }
}