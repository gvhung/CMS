﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public interface ICompany
    {
        long CompanyId { get; set; }
        string CompanyName { get; set; }
        bool Validate();

    }
}
