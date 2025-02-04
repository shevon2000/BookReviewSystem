namespace BookReviewSystem.API.Models.Domain
{
    public class Book
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public DateOnly PublishedYear { get; set; }
        public Guid AuthorId { get; set; }

        public required Author Author { get; set; }
    }
}
