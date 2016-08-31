using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRM.DAL.Entities
{
    public class CRMUser : IEntity
    {
        public long CreatedBy{get; set;}

        DateTime? dateCreated;
        public DateTime DateCreated {
            get { return dateCreated ?? System.DateTime.Now; }

            set { dateCreated = value; }
        }
        
        public DateTime? DateModified {get; set;}
        
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UID{get; set;}

        
        [Required]
        //[Index(IsClustered =false, IsUnique =true)]   
        public string UserId { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public string Name { get; set; }
        

        [Required]
        [DefaultValue(0)]
        public int Status { get; set; }

        
        public long CustomerId { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public class UserType : IEntity
    {
        public string Description { get; set; }

        public long CreatedBy
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateCreated
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? DateModified
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int UserTypeId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Status
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
