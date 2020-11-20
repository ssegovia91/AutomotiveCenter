using AutomotiveCenter.Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveCenter.Application.Entities
{
    public class User: EntityBase
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        [ForeignKey("role")]
        public int roleId { get; set; }

        public Role role { get; set; }
    }
}
