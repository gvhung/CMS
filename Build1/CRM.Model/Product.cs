﻿using CRM.Model.Interfaces;
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
        public string CompanyName { get; set; }
        public string Description { get; set;}
        public string Versions { get; set; }
        public long CompanyId { get; set; }
        public long VersionId { get; set; }
        public string Components { get; set; }
        public long ComponentId { get; set; }
       
        public bool Validate()
        {
            //  if (String.IsNullOrEmpty(Name.Trim())) throw new Exception("Product name is empty");
            if (Name == null || Name == "") throw new Exception("name is invalid");
            return true;
        }
    }
}
