using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CRM.Store.Entities
{

    [Table("Clients")]
    public class ClientEntity
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string TicketStartNumber { get; set; }

        public IEnumerable<BranchEntity> Branches { get; set; }
    }

    [Table("Branches")]
    public class BranchEntity
    {
        [Key]
        public int BranchId { get; set; }
        
        
        public string BracnhName { get; set; }
        public string BranchCode { get; set; }
        public long TicketStartNumber { get; set; }
        public int ClientId {get; set;}
        public ClientEntity Client { get; set; }
    }


}
