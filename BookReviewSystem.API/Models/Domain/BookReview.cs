using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewSystem.API.Models.Domain
{
    public class BookReview
    {
        [Key]
        public Guid ReviewId { get; set; }
        [Required]
        public required string ReviwerName { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }     // 1 - 5
        public string? ReviewText { get; set; }
        [ForeignKey("BookId")]
        public Guid BookId { get; set; }

        public required Book Book { get; set; }
    }
}
