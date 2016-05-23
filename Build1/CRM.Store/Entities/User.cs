using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CRM.Store.Entities
{
     [Table("UserProfiles")]
    public class UserProfileEntity
    {
       [System.ComponentModel.DataAnnotations.Key]
        public long UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public int Status { get; set; }

        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
    [Table("Logins")]
    public class LoginEntity
    {
        [Key]
        public long UID { get; set; }
        /// <summary>
        /// Username is email address
        /// </summary>
        public string Username { get; set; }
        
    }
}
