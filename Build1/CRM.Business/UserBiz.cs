using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Dal;
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
    }
}
