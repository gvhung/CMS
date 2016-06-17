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

        public  int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
        public CompanyEntity Client { get; set; }

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
    public class ProductVersions
    {
       public int ProductId { get; set; }
        public string version { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public DateTime DateRelesed { get; set; }

        public ProductEntity Product { get; set; }
    }

}
