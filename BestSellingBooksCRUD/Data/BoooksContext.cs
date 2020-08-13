using System;
using BestSellingBooksCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BestSellingBooksCRUD.Data
{
    public class BoooksContext : DbContext
    {
        public BoooksContext(DbContextOptions<BoooksContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ISBN> ISBNs { get; set; }
        public DbSet<RankHistory> RankHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>().HasMany(b => b.RankHistories);
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<ISBN>().ToTable("ISBN");
            modelBuilder.Entity<RankHistory>().ToTable("RankHistory");
        }
    }
}
