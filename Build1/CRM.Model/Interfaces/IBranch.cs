using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Interfaces
{
   public interface IBranch
    {
         string BracnhName { get; set; }
         string BranchCode { get; set; }
         bool Validate();

    }
}
