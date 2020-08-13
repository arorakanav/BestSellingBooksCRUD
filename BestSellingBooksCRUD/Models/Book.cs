using System;
using System.Collections.Generic;

namespace BestSellingBooksCRUD.Models
{
    public class Book
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public ISBN ISBNs { get; set; }
        public ICollection<RankHistory> RankHistories { get; set; }


    }
}
