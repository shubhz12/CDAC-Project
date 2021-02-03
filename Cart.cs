using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public  class Cart
    {
        [Required]
        public int cart_id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Total_amount { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
