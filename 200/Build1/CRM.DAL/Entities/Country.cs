using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Entities
{
    public class Country:IEntity
    {
        
        public string CountryName { get; set; }

        public long CreatedBy
        {
            get; set;
        }
        DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }

        public DateTime? DateModified
        {
            get; set;
        }

        public long CountryId
        {
            get; set;
        }
        [Required]
        [DefaultValue(1)]
        public int Status { get; set; }

        
    }
}
