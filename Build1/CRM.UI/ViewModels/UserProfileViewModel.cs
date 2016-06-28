using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UI.ViewModels
{
    public class UserProfileViewModel
    {
        public long UID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifed { get; set; }
        public long CreatedBy { get; set; }
        public int UserType { get; set; }
        public long CompanyId { get; set; }

    }
}