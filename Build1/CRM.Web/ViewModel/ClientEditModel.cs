using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRM.Web.ViewModel
{
    public class ClientEditModel
    {
        [Display(Name="Client ID")]
        public int ClientId { get; set; }
        [Display(Name = "Client Name")]
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConformPassword { get; set; }
    }
}