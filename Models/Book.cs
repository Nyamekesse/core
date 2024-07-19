using System.ComponentModel.DataAnnotations.Schema;
using ef_core.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }

    [NotMapped]
    public string PriceRange { get; set; }
    public virtual BookDetail BookDetail { get; set; }

    [ForeignKey("Publisher")]
    public int Publisher_Id { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual List<BookAuthorMap> BookAuthorMap { get; set; }

    [NotMapped]
    public virtual List<BookAuthorMap> BookAuthors { get; set; }
}
