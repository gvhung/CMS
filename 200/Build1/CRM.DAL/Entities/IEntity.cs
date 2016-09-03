using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Entities
{
    public interface IEntity
    {
        
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        long CreatedBy { get; set; }
        int Status { get; set; }
        
    }
}
