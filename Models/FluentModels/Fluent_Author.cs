namespace ef_core;

public class Fluent_Author
{
    public int Author_Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Location { get; set; }

    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }

    public virtual List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
}
