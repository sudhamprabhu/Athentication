﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthBLL.Entities
{
    public class OrganizationDTO
    {
        public int OrganizationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
        public string PhoneNo { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
    }
}
