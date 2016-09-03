using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace CRM.DAL.Entities
{
    public class Ticket:BaseEntity
    {
       
        public long TicketId { get; set; }
        public long TicketNo { get; set; }
        public string Title { get; set; }

        public int PriorityId { get; set; }
        public int SeviorityId { get; set; }
        
        public virtual Seviority Seviority { get; set; }
        public virtual Priority Priority { get; set; }
        
        public long PrimaryAssignee { get; set; }

        [ForeignKey("PrimaryAssignee")]
        public virtual CRMUser CRMUser { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<CRMUser> SecondaryAssignees { get; set; }
    }
    
    public class Seviority: BaseEntity
    {
        public int SeviorityId { get; set; }
        public string Description { get; set; }
    }
    public class Priority:BaseEntity
    {
        public int PriorityId { get; set; }
        public string Description { get; set; }
    }



    public class TicketAttachment:BaseEntity
    {
        [Key]
        public long AttachmentId { get; set; }
        
        public byte[] Data { get; set; }
        public long TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
     
    }
    public class TicketComment:BaseEntity
    {
        public long TicketCommentId { get; set; }
        [MaxLength(4000)]
        public string Comment { get; set; }
        public long TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

    }
}
