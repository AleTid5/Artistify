﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Status
    {
        public string Code { set; get; }
        public string Name { set; get; }

        override
        public String ToString()
        {
            return this.Name.ToString();
        }
    }
}
