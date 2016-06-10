using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRM.Store.Entities
{
    [Table("Products")]
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public long ClientId { get; set; }

        public string Description { get; set; }
        public ClientEntity Client { get; set; }

        public IEnumerable<Module> Modules { get; set; }
    }

    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ModuleId { get; set; }
        public string Name { get; set; }

        public long ProductId { get; set; }
        public ProductEntity Product { get; set; }

    }
}
