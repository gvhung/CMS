using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Model;
using System.ComponentModel.DataAnnotations;
namespace CRM.UI.ViewModels
{
   // public class ProductListVM
    //{  
    //  
    //    [Required]
    //    [Display(Name="Product Name")]
    //    public string ProductName { get; set; }
    //    [Required]
    //    [Display(Name="Versions")]
    //    public string Version { get; set; }
    //    [Required]
    //    [Display(Name="Company Name")]
    //    public string CompanyName { get; set; }
    //    public string ProductId { get; set; }
    //    public long VersionId { get; set; }
    //    [Required]
    //    [Display(Name="Components")]
    //    public string Components { get; set; }
    //    public long ComponentId { get; set; }
    //}

    public class ProductListVM
    {
        
        public List<Product> Products { get; set;}
        public List<Component> Components { get; set;}
        public List<ProductVersion> Versions { get; set;}

        public ProductListVM()///////create constructor
        {
            Products = new List<Product>();
            Versions = new List<ProductVersion>();
            Components = new List<Component>();
        }

    }
      


    public class ProductEditVM
    {  
        [Required(ErrorMessage="Enter ProductName")]
        [Display(Name="Product Name")]
        public string ProductName { get; set;}
        [Required(ErrorMessage="Enter Versions")]
        [Display(Name="Versions")]
        public string Versions { get; set; }
        public string OldVersion { get; set; }
        public long ProductId { get; set; }
        [Required(ErrorMessage="Enter Components")]
        [Display(Name="Components")]
        public string Components { get; set; }
        public string OldComponents { get; set; }

        public ProductEditVM()
        {
        }

    }
   
    public class CreateNewProductVM
    {
        [Required(ErrorMessage = "Enter ProductName")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Versions { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        public List<Company> Compaines { get; set; }
        public long CompanyId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Components ")]
        public string Components{ get; set; }


    }
}