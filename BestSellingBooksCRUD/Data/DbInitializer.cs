using System;
using System.Linq;
using BestSellingBooksCRUD.Models;
using Newtonsoft.Json.Linq;

namespace BestSellingBooksCRUD.Data
{
    public class DbInitializer
    {
        public static void Initialize(BoooksContext context)
        {

            
            context.Database.EnsureCreated();

            // Look for any Books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            //Book[] books = new Book[0];
            var booksId = 1;
            var ISBNId = 1;
            var RankID = 1;
            // Get json result
            // Fetch first 200 responses from API and offset is used to get the next 20 response from the api. 
            JObject json = GetBooksData.GetBestSellerItems(200);

            // Get Results Array from Json
            var results = json["results"];
            foreach (JObject ele in results)
            {
                // Data for Books
                var title = ele["title"];
                var description = ele["description"];
                var author = ele["author"];
                var publisher = ele["publisher"];

                var book = new Book();
                book.Title = (String)title;
                book.Description = (String)description;
                book.Author = (String)author;
                book.Publisher = (String)publisher;
                book.BookId = booksId.ToString();
                Console.WriteLine(book);
                context.Books.Add(book);
                context.SaveChanges();

                // Data for ISBN
                var isbns = ele["isbns"];
                var isbn = new ISBN();
                if (isbns.HasValues)
                {
                    var isbn10 = isbns[0]["isbn10"];
                    var isbn13 = isbns[0]["isbn13"];
                    isbn.BookId = booksId.ToString();
                    isbn.ISBNId = ISBNId.ToString();
                    isbn.Isbn10 = (String)isbn10;
                    isbn13 = (String)isbn13;
                    context.ISBNs.Add(isbn);
                    context.SaveChanges();
                    ISBNId += 1;
                }

                // Data for rank histories
                var rankhistories = ele["ranks_history"];
                foreach(JObject rankHistoryele in rankhistories)
                {
                    
                    var rank = (String)rankHistoryele["rank"];
                    var listName = (String)rankHistoryele["list_name"];
                    var weeksOnList = (String)rankHistoryele["weeks_on_list"];

                    var rankHistory = new RankHistory();
                    rankHistory.ID = RankID.ToString();
                    rankHistory.BookId = booksId.ToString();
                    rankHistory.Rank = (String)rank;
                    rankHistory.ListName = (String)listName;
                    rankHistory.WeeksOnList = (String)weeksOnList;
                    context.RankHistories.Add(rankHistory);
                    context.SaveChanges();
                    RankID += 1;

                }

                booksId += 1;
                
            }

            

        }

    }
}
