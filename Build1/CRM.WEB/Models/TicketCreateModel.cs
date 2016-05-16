using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Models
{
    public class TicketCreateModel
    {
        public int Id {get;set;}
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }

        public string FileUpload { get; set; }
        
        public string DueDate { get; set; }
        public string SeverityCode { get; set; }

        public string Version { get; set; }
        public string ProductId { get; set; }
        [Display(Name="Module")]
        public string ModuleId { get; set; }
        public string IssueType { get; set; }


        public List<Product> Products { get; set; }

        public List<Module> Modules { get; set; }

        public List<Severity> Severities { get; set; }
        
                     

    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Module
    {
        public int Id{get;set;}
        public string Name{get;set;}

      
       
    }
    public class Severity
    {
        public int Code { get; set; }
        public string Name { get; set; }

       

    }
}