using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wood.Models;

public partial class Author
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Author_name")]
    public string AuthorName { get; set; } = null!;

    [Column("Athor_img")]
    public string AthorImg { get; set; } = null!;

    [Column("Author_description")]
    public string? AuthorDescription { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
