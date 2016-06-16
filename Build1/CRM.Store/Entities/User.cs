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
    public class UserProfileEntity:BaseEntity
    {
        [Key]
        public Guid UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
       [Index(IsClustered =false, IsUnique =true)]
       [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Status { get; set; }
       
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
    [Table("Logins")]
    public class LoginEntity
    {
        [Key]
        public Guid UID { get; set; }
        /// <summary>index
        /// Username is email address
        /// </summary>
        public string Username { get; set; }
        
    }


}
