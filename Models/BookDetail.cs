using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookDetail
{
    [Key]
    public int BookDEtail_I { get; set; }

    [Required]
    public int NumberOfChapters { get; set; }

    public int NumberOfPages { get; set; }

    public double Weight { get; set; }

    [ForeignKey("Book")]
    public int Book_Id { get; set; }
    public Book Book { get; set; }
}