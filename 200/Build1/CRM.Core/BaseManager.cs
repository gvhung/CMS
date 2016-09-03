using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL.Interfaces;
namespace CRM.Core
{
    public abstract class BaseManager
    {
        protected IUnitOfWork uow;
        public BaseManager(IUnitOfWork uow)
        {
            this.uow = uow;

        }
    }
}
