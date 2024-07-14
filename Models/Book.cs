using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }

    [NotMapped]
    public string PriceRange { get; set; }
    public BookDetail BookDetail { get; set; }

    [ForeignKey("Publisher")]
    public int Publisher_Id { get; set; }
    public Publisher Publisher { get; set; }
}