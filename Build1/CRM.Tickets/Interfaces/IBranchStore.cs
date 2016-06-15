using CRM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
namespace CRM.Tickets.Interfaces
{
   public interface IBranchStore<TBranch> where TBranch:IBranch
    {
        void CreateBranch(TBranch branch);
        IQueryable<TBranch> GetBranches();
    }
}
