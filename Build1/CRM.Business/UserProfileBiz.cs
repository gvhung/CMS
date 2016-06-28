using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Dal;

namespace CRM.Business
{
    public class UserProfileBiz
    {
        public void Create(CRMUser user)
        {
            UserProfileDal userProfileDal = new UserProfileDal();
            userProfileDal.Create(user);
        }
    }
}
