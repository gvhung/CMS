using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Tickets.Interfaces
{
    public interface IUserStore<TUser>
        where TUser : CRM.Model.IUser
    {
        void CreateUser(TUser user);
        IQueryable GetAllUsers();
        TUser GetUser(string emailId);
        void ActivateUser(Guid id);
    }
}
