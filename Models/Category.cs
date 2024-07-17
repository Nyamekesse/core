using System.ComponentModel.DataAnnotations.Schema;

public class Category
{
    public int Id { get; set; }

    [Column("Name")]
    public string CategoryName { get; set; }
}
