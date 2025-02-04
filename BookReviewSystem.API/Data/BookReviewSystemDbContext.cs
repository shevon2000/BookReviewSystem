using BookReviewSystem.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookReviewSystem.API.Data
{
    public class BookReviewSystemDbContext : DbContext
    {
        public BookReviewSystemDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
    }
}
