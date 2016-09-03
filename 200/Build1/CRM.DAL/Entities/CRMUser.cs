using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace CRM.DAL.Entities
{
    public class CRMUser : BaseEntity
    {
       
              
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UID{get; set;}
       
        [Required]
        //[Index(IsClustered =false, IsUnique =true)]   
        public string LoginId { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public string Name { get; set; }
        public long CustomerId { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public class UserType : BaseEntity
    {
        public string Description { get; set; }

       
        public int UserTypeId
        {
            get; set;
        }

       
    }
}
