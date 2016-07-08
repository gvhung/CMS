using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Model;
namespace CRM.UI.ViewModels
{
    public class ProductListVM
    {
        public string ProductName { get; set; }
        public string Version { get; set; }
        public string CompanyName { get; set; }
        public string ProductId { get; set; }
    }

    public class ProductEditVM
    {
        public string ProductName { get; set; }
        public string Versions { get; set; }
        //Drpdown properties
        public long CompanyId { get; set; }  ///dropdown selection
        public List<Company> Companies { get; set; }

        public ProductEditVM()
        {
            Companies = new List<Company>();
        }

    }
    

}