using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL.Interfaces;
using CRM.DAL.Entities;

namespace CRM.DAL
{
    public class UserRepository : RepositoryBase<CRMUser>, IUserRepository
    {
        public UserRepository(IRepositoryContext context):base(context)
        {

        }

        public CRMUser GetUserByLoginId(string loginId)
        {
            return Context.GetEntities<CRMUser>().FirstOrDefault(u => u.LoginId == loginId);
        }

        public CRMUser GetUserByUID(long uid)
        {
            return Context.GetEntities<CRMUser>().FirstOrDefault(u => u.UID == uid);
        }

    }
}
