using AutomotiveCenter.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveCenter.Application.Entities
{
    public class Role: EntityBase
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
    }
}
