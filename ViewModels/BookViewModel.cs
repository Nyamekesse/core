using Microsoft.AspNetCore.Mvc.Rendering;

namespace ef_core.ViewModels;

public class BookViewModel
{
    public Book Book { get; set; }
    public IEnumerable<SelectListItem> PublisherList { get; set; }
}
