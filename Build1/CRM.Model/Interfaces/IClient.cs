using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public interface IClient
    {
        int ClientId { get; set; }
        string Name { get; set; }
        bool Validate();

    }
}
