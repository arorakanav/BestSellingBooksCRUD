using System;
namespace BestSellingBooksCRUD.Models
{
    public class ISBN
    {
        public string ISBNId { get; set; }
        public string BookId { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public Book Books { get; set; }
    }
}
