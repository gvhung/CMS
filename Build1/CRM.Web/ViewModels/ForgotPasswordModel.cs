using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage="Enter email address with which you registerd")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage="Enter below security code (case sensitive)")]
        public string SecurityCode { get; set; }


    }
}