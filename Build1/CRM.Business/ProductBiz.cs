﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Dal;
namespace CRM.Business
{
    public class ProductBiz
    {
        public void AddProduct(Product p)
        {
            if (p.Validate())
            {
                ProductDB productDB = new ProductDB();
                productDB.AddProduct(p);
            }
        }
    }
}