using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRM.DAL.Entities
{
    [Table("StatusMaster")]
   public class StatusMaster
    {
        [Key]
        public int StatusId { get; set; }
        public string Description { get; set; }
        public bool IsCustom { get; set; }
        public int StatusTypeId { get; set; }
        public virtual StatusType StatusType { get; set; }

    }
    public class StatusType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusTypeId { get; set; }
        public string Description { get; set; }
    }
}
