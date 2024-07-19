namespace ef_core;

public class Fluent_Book
{
    public int Book_Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public string PriceRange { get; set; }
    public Fluent_BookDetail BookDetail { get; set; }
    public int Publisher_Id { get; set; }
    public virtual Fluent_Publisher Publisher { get; set; }
    public virtual List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
}
