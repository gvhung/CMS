using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRM.Store.Entities
{
    [Table("Tickets")]
    public class TicketEntity
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
            
        public long TicketNo { get; set; }
        public int BranchId { get; set; }
        public BranchEntity Branch { get; set; }
    }
}
