using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRM.Store.Entities
{

    public class UserProfileEntity
    {
        [Table("UserProfiles")]
        public long UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

    }

    public class LoginsEntity
    {
        public long UID { get; set; }
        public string Username { get; set; }
        
    }
}
