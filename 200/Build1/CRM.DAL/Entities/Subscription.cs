using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlairBees.Common;
namespace CRM.DAL.Entities
{
    public class Subscription
    {

        public int SubscriptionId { get; set; }
        [Required]
        public string SubscriptionName { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int NoOfUsers { get; set; }  // -999 for unlimited users
        [Required]
        public int Duration { get; set; }  // duration in days,  -999 for lifetime

        [Required]
        public int MaxAttachmentSize { get; set; }  // in terms of MB
        [Required]
        public long MaxAttachments { get; set; }

        [Required]
        public int Status { get; set; }

        [Column("SubscriptionType")]
        public string SubscriptionTypeString
        {
            get
            {
                return this.SubscriptionType.ToString();
            }
            private set
            {
                this.SubscriptionType = value.ParseEnum<SubscriptionType>();
            }
        }
        [NotMapped]
        public SubscriptionType SubscriptionType { get; set; }

    }

    public enum SubscriptionType
    {
        Seeded,
        Custom
    }

}
