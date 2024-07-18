using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ef_core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ef_core.ViewModels
{
    public class BookAuthorViewModel
    {
        public BookAuthorMap BookAuthor { get; set; }
        public Book Book { get; set; }

        public IEnumerable<BookAuthorMap> BookAuthorList { get; set; }

        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
