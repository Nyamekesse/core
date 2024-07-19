﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_core;

public class Fluent_BookDetail
{
    public int BookDetail_Id { get; set; }
    public int NumberOfChapters { get; set; }
    public int NumberOfPages { get; set; }
    public string Weight { get; set; }
    public int Book_Id { get; set; }
    public virtual Fluent_Book Book { get; set; }
}
