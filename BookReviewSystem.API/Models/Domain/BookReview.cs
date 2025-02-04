namespace BookReviewSystem.API.Models.Domain
{
    public class BookReview
    {
        public Guid ReviewId { get; set; }
        public required string ReviwerName { get; set; }
        public int Rating { get; set; }     // 1 - 5
        public string? ReviewText { get; set; }
        public Guid BookId { get; set; }

        public required Book Book { get; set; }
    }
}
