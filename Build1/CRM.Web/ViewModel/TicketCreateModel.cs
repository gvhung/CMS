using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using static CRM.Model.Ticket;

namespace CRM.Web.ViewModel
{
    public class TicketCreateModel
    {
       [Required(ErrorMessage ="Enter Title")]
        public string Title { get; set; }
        [AllowHtml]
        [Required(ErrorMessage ="Enter Description")]
        public string Description { get; set; }
        public string FileUpload { get; set; }
        [Display(Name ="Priority")]
        public int SeverityCode { get; set; }
        public long VersionId { get; set; }
        [Display(Name ="Product")]
        public int ProductId { get; set; }
        [Display(Name = "Module")]
        public int ModuleId { get; set; }
        public int TicketType { get; set; }
        //public List<Product> Products { get; set; }
        //public List<Module> Modules { get; set; }
        //public List<Priority> Priorities { get; set; }

        List<Product> Products = new List<Product>();
        List<ProductVersion> Versions = new List<ProductVersion>();
        List<TicketType> TicketTypes = new List<TicketType>();
        List<Priority> Priorities = new List<Priority>();
        List<Seviority> Seviorities = new List<Seviority>();

        



    }


    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Priority
    {
        public int Code { get; set; }
        public string Name { get; set; }

    }
}