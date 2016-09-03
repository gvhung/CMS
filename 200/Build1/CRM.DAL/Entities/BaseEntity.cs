using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        
        public long CreatedBy
        {
            get; set;
        }
        DateTime? dateCreated;

        public DateTime DateCreated
        {
            get {
                return dateCreated ?? DateTime.Now;
            }
            set { dateCreated = value; }
        }

        public DateTime? DateModified
        {
            get;set;         
        }
        [DefaultValue(0)]
        [ForeignKey("StatusMaster")]

        public int Status
        {
            get; set;
        }
        
        public virtual StatusMaster StatusMaster { get; set; }
    }
}
