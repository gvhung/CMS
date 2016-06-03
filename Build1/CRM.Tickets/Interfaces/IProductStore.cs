using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Model.Interfaces;

namespace CRM.Tickets.Interfaces
{
    public interface IProductStore<TProduct> where TProduct :IProduct
    {
        IQueryable<TProduct> GetProducts();
    }
}
