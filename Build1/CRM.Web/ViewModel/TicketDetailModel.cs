using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class TicketDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUpload { get; set; }

        public string DueDate { get; set; }
        public string SeverityCode { get; set; }

        public string Version { get; set; }
        public string ProductId { get; set; }
        [Display(Name = "Module")]
        public string ModuleId { get; set; }
        public string IssueType { get; set; }

    }
}