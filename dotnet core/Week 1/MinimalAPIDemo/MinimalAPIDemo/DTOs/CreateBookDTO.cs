using System.ComponentModel.DataAnnotations;

namespace MinimalAPIDemo.DTOs
{
    public class CreateBookDTO
    {
        [Required(ErrorMessage ="Book title is required")]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        [MinLength(10)]
        public string Author { get; set; }
    }
}
