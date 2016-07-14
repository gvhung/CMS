using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;

namespace CRM.UI.ViewModels
{
    public class TicketCreateModel
    {
        public long TicketNo { get; set; }
        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }
        [Display(Name = "Product")]
        public long ProductId { get; set; }
        [Display(Name = "Component")]
        public long ComponentId { get; set; }
        public string Version { get; set; }
        public int Status { get; set; }
        [Display(Name ="Company")]
        public long CompanyId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long CreatedBy { get; set; }
        public DateTime DateFixed { get; set; }
        public DateTime DateClosed { get; set; }
        public string ComponentName { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }

        public List<Company> lstModel { get; set; }

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
