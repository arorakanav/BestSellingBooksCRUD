using System;
namespace BestSellingBooksCRUD.Models
{
    public class RankHistory
    {
        public string ID { get; set; }
        public string BookId { get; set; }
        public string Rank { get; set; }
        public string ListName { get; set; }
        public string WeeksOnList { get; set; }

        public Book Books { get; set; }
    }
}
