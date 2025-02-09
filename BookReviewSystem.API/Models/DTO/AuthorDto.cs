namespace BookReviewSystem.API.Models.DTO
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
