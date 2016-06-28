using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public interface IUser
    {
        long UID { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModifed { get; set; }
        long CreatedBy { get; set; }
        int UserType { get; set; }
        long CompanyId { get; set; }
        Guid Guid { get; set; }

        //string Username { get; set; }
        //string FirstName { get; set; }
        //string LastName { get; set; }
        //string Password { get; set; }
        //int UserType { get; set; }
        //int Status { get; set; }
        //DateTime DateCreated { get; set; }
        //Guid UID { get; set; }
        bool Validate();

    }
}
