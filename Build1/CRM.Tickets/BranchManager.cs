using CRM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Tickets.Interfaces;

namespace CRM.Tickets
{
    public class BranchManager<TBranch> where TBranch : IBranch
    {
        IBranchStore<TBranch> _branchStore;
        public BranchManager(IBranchStore<TBranch> branchStore)
        {
            _branchStore = branchStore;
        }

        public void CreateBranch(TBranch branch)
        {
            _branchStore.CreateBranch(branch);
        }

        public IQueryable<TBranch> GetBranches()
        {
            return _branchStore.GetBranches();
        }
    }
}
