using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UI.ViewModels
{
    public class CreateTemplateViewModel
    {
        public int TemplateId { get; set; }
        public string Template { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
        public long CompanyId { get; set; }
    }
}