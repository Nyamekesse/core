using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Author
{
    [Key]
    public int Author_Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    public int LastName { get; set;}

    public DateTime BirthDate { get; set; }

    public string Location { get; set; }

    [NotMapped]
    public string FullName 
    { 
        get {
        return $"{FirstName} {LastName}";
    } 
    }
}