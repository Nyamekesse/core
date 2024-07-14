
using System.ComponentModel.DataAnnotations.Schema;

[Table("tb_genres")]
public class Genre
{
    public int Id { get; set; }
    [Column("Name")]
    public string GenreName { get; set; }

    public int DisplayOrder { get; set; }

}