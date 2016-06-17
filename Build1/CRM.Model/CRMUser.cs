
using System;

namespace CRM.Model
{
    public class CRMUser : IUser
    {
        public DateTime DateCreated{get; set;}

        public string FirstName{ get; set;}

        public string LastName{ get; set;}

        public string Username{ get; set;}
        public int UserType { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }

        public Guid UID { get; set; }
      
        public bool Validate()
        {
            if (Username == "") throw new Exception("Username is empty");
            if (Password ==null ||Password.Trim() == "") throw new Exception("Invalid password");

            return true;
        }
    }
}
