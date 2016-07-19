using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class ProductVersion
    {
        public long VersionId { get; set; }
        public string VersionName { get; set; }
        public long ProductId { get; set; }
        public int Status { get; set; }
        
    }
}
