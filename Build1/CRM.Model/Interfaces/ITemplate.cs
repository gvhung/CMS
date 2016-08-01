using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Interfaces
{
   public interface ITemplate
    {
        int TemplateId { get; set; }
        string Template { get; set; }
        string Name { get; set; }
        string Subject { get; set; }
        int Status { get; set; }
        long CompanyId { get; set; }
    }
}
