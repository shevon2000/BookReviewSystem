namespace BookReviewSystem.API.Models.Domain
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
