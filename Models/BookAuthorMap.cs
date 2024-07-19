using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core.Models
{
    public class BookAuthorMap
    {
        [ForeignKey("Book")]
        public int Book_Id { get; set; }

        [ForeignKey("Author")]
        public int Author_Id { get; set; }
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
