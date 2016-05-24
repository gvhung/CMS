
using System;

namespace CRM.Model
{
    public class CRMUser : IUser
    {
        public string FirstName
        {
            get; set;
            
        }

        public string LastName
        {
            get; set;
        }

        public string Username
        {
            get; set;
        }
    }
}
