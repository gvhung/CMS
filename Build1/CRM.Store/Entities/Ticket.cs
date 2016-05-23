using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.IO;
namespace CRM.Store.Entities
{
    [Table("Tickets")]
    public class TicketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TickeId { get; set; }
            
        public long TicketNo { get; set; }
        public int BranchId { get; set; }
        public BranchEntity Branch { get; set; }
    }

    public class TicketComment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TicketId { get; set; }
        public string Message { get; set; }
        public TicketEntity Ticket { get; set; }
    }

    public class Attachment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Filename { get; set; }

        public Stream Content { get; set; }

        public string ContentType { get; set; }
        public string Extension { get; set; }
        public DateTime DateCreated { get; set; }

        public long ReferenceId { get; set; }

        public int ReferenceType { get; set; }

        public long CreatedBy { get; set; }

    }
}
