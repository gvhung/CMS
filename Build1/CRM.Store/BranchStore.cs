using CRM.Model.Interfaces;
using CRM.Store.Entities;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Store
{
    public class BranchStore<TBranch> : IBranchStore<TBranch> where TBranch:IBranch
    {
        CRMContext _context;

        public BranchStore():this("CRMContext")
        {

        }
        public BranchStore(string constr)
        {
            _context = new CRMContext(constr);
        }

        public BranchStore(CRMContext context)
        {
            _context = context;
        }

        public void CreateBranch(TBranch branch)
        {
            BranchEntity branchEntity =(BranchEntity) AutoMapper.Mapper.Map<BranchEntity>(branch);
            _context.Branches.Add(branchEntity);
            _context.SaveChanges();
        }

        public IQueryable<TBranch> GetBranches()
        {
            throw new NotImplementedException();
        }
    }
}
