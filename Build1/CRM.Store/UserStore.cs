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
    public class UserStore<TUser> : IUserStore<TUser> where TUser : IUser
    {
        CRMContext _context;

        public UserStore() : this("CRMContext")
        {
        }
        public UserStore(string constr)
        {
            _context = new CRMContext(constr);
        }
        public void CreateUser(TUser user)
        {
            throw new NotImplementedException();
        }

        public TUser GetUser(string emailId)
        {

            LoginEntity loginEntity = _context.Logins.FirstOrDefault(l => l.Username.ToUpper() == emailId.ToUpper());
            if (loginEntity == null) return default(TUser);

            UserProfileEntity userProfile = _context.Users.FirstOrDefault(u => u.UID == loginEntity.UID);

            return AutoMapper.Mapper.Map<TUser>(userProfile);

        }


        public IQueryable GetAllUsers()
        {
            throw new NotImplementedException();
        } 

        public void UserActivate(Guid id)
        {
            //UserProfileEntity userEntity = AutoMapper.Mapper.Map<UserProfileEntity>(id);
            UserProfileEntity c = (from x in _context.Users
                                   where x.UID == id
                          select x).First();
            c.Status = 1;
            //dataBase.SaveChanges();
            _context.Entry(c).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
                        
        }
    }
}
