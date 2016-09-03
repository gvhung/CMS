using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL.Entities;
namespace CRM.DAL.Interfaces
{
   public interface IUserRepository:IRepository<CRMUser>
    {
        CRMUser GetUserByUID(long uid);
        CRMUser GetUserByLoginId(string userId);
    }
}
