using CRM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Product:IProduct
    {
        
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
