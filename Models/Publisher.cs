using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Publisher
{
    [Key]
    public int Publisher_Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Location { get; set; }

    public virtual List<Book> Books { get; set; }
}
