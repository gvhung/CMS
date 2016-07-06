using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.UI.ViewModels
{
    public class UserProfileViewModel
    {
        public long UID { get; set; }
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifed { get; set; }
        public long CreatedBy { get; set; }
        public int UserType { get; set; }
        public long CompanyId { get; set; }
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }

    }
}