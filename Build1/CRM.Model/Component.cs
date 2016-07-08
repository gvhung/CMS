using CRM.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Component : IComponent
    {
        public long ComponentId { get; set; }
        public string ComponentName { get; set; }
        public long Product { get; set; }
        public int Status { get; set; }

        public bool Validate
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
