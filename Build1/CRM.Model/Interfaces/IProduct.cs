using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Interfaces
{
    public interface IProduct
    {
        
        string Name { get; set; }
        long Id { get; set; }
    }
}
