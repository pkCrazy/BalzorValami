using System.ComponentModel.DataAnnotations;

namespace BalzorValami.Shared.Admin;

public class Post
{
    [Required]
    [StringLength(256, ErrorMessage = "Túl hosszú cím")]
    public string? Title { get; set; }

    [Required]
    [StringLength(5000, ErrorMessage = "Túl hosszú")]
    public string? Body { get; set; }

    [Required]
    public string? AuthorId { get; set; }
}
