using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Dal;
using CRM.Model;

namespace CRM.Business
{
    public class UserBiz
    {

        public bool IsEmailIdExists(string emailId)
        {
            if (emailId == null || emailId.Trim() == "")
                throw new Exception("Please provide email address");
            else
            {
                UserDB userDB = new UserDB();
                return userDB.IsEmailIdExists(emailId);
            }
        }

        public long CreateCompany(string companyName)
        {
            UserDB userDB = new UserDB();
            return userDB.CreateCompany(companyName);
        }

        public bool Login(string userName, string pswd, out long UID,out long companyId)
        {
            UserDB userdb = new UserDB();
           bool status= userdb.Login(userName, pswd,out UID,out companyId);
            return status;
        }

        public string RegisterUser(CRMUser user)
        {
            UserDB userDB = new UserDB();
          return userDB.RegisterUser (user);
        }

        public void Activate(string id)
        {
            UserDB userDal = new UserDB();
            userDal.Activate(id);
        }

        public void UpdateUserProfile(CRMUser userProfile)
        {
            UserDB userProfiledb = new UserDB();
            userProfiledb.UpdateUserProfile(userProfile);
        }

        public CRMUser GetUserProfile(long id)
        {
            UserDB getUser = new UserDB();
            return getUser.GetUserProfile(id );
           
        }
                
    }
        
}
