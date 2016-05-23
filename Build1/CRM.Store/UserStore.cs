using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Tickets.Interfaces;
using CRM.Model;
using CRM.Store.Entities;
namespace CRM.Store
{
    public class UserStore<TUser>:IUserStore<TUser> where TUser:IUser
    {
        ICRMContext _context;
        public UserStore(ICRMContext context)
        {
            _context = context;
        }
        public void CreateUser(TUser user)
        {
            throw new NotImplementedException();
        }

        public TUser GetUser(string emailId)


        {
            LoginEntity loginEntity = _context.Logins.First(l => l.Username == emailId);
            UserProfileEntity userProfile= _context.Users.First(u => u.UID == loginEntity.UID);

            return AutoMapper.Mapper.Map<TUser>(userProfile);
            
        }


        public IQueryable GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
