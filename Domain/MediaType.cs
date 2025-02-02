﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MediaType
    {
        public int Id { set; get; }
        public string Type { set; get; }
        public Status Status { set; get; }

        override
        public String ToString()
        {
            return this.Type.ToString();
        }
    }
}
