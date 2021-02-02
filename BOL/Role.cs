using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class Role
    {
        [Required]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
