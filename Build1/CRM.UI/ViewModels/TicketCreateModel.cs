using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using static CRM.Model.Ticket;

namespace CRM.UI.ViewModels
{
    public class TicketCreateModel
    {
        public long TicketNo { get; set; }
        public long TicketId { get; set; }
        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }
        [Display(Name = "Product")]
        public long ProductId { get; set; }
        [Display(Name = "Component")]
        public long ComponentId { get; set; }
        [Display(Name = "Version")]
        public long VersionId { get; set; }
        public int Status { get; set; }
        [Display(Name = "Company")]
        public long CompanyId { get; set; }
        public string ComponentName { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }
        [Display(Name = "Seviority")]
        public int SeviorityId { get; set; }
        [Display(Name = "Ticket Type")]
        public int TicketTypeId { get; set; }


        public List<Product> Products { get; set; }
        public List<Component> Components { get; set; }
        public List<ProductVersion> Versions { get; set; }
        public List<Priority> Priorities { get; set; }
        public List<Seviority> Seviorities { get; set; }
        public List<TicketType> TicketTypes { get; set; }
        //public List<Ticket> ticket { get; set; }

        public TicketCreateModel()
        {
            Components = new List<Component>();
            Products = new List<Product>();
            Versions = new List<ProductVersion>();
            Priorities = new List<Priority>();
            Seviorities = new List<Seviority>();
            TicketTypes = new List<TicketType>();
        }
    }





}
