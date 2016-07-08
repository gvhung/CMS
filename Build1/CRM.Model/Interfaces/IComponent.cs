using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Interfaces
{
    interface IComponent
    {
        long ComponentId { get; set; }
        string ComponentName { get; set; }
        int Status { get; set; }
        long Product { get; set;}
        bool Validate  { get; set; } 
    }
}
