using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BOL
{
    public class Users
    {

        [Required]
        public int user_id { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public int contact_no { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string role { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int Zip { get; set; }

    }
}
