using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SubCategory
{
    [Key]
    public int SubCategory_Id { get; set; }

    [Required]
    public string Name { get; set; }
}