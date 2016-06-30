using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRM.UI.ViewModels
{
    public class UserRegisterVM
    {
        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Company or Organisation Name")]
        [Required]
        public string CompanyName { get; set; }
    }
}