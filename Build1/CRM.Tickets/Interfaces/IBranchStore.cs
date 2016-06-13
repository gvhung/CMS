using CRM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tickets.Interfaces
{
   public interface IBranchStore<TBranch> where TBranch:IBranch
    {
        void Create(TBranch branch);
        IQueryable<TBranch> GetBranches();
    }
}
