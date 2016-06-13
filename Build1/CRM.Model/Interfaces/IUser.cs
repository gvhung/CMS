using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public interface IUser
    {


        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
         int UserType { get; set; }
        int Status { get; set; }
        DateTime DateCreated { get; set; }
        bool Validate();

    }
}
