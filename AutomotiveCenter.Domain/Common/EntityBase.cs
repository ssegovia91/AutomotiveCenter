using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveCenter.Application.Common
{
    public class EntityBase
    {
        public string UserNameCreated { get; set; }
        public string UserNameUpdated { get; set; }
        public string UserNameDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
