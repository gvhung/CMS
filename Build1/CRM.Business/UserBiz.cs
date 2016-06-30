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

        public bool UseLogin(string userName, string pswd)
        {
            UserDB userdb = new UserDB();
           bool status= userdb.UserLogin(userName, pswd);
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
    }
        
}
