using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Books
    {
        [Required]
        public int Book_id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int count { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Title { get; set; }


    }
}
