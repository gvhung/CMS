using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Tickets.Interfaces;
namespace CRM.Tickets
{
    public class UserManager<TUser> where TUser:IUser
    {
        IUserStore<TUser> userStore;
        public UserManager(IUserStore<TUser> userStore)
        {
            this.userStore = userStore;
        }
        public TUser GetUser(string emailId)
        {
            return userStore.GetUser(emailId);
        }

        public void UserActivate(Guid id)
        {
             userStore.UserActivate(id);
        }
    }
}
