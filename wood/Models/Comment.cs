using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wood.Models;

public partial class Comment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("User_id")]
    public string UserId { get; set; } = null!;

    [Column("Comment")]
    public string? Comment1 { get; set; }

    [Column("Comment_point", TypeName = "INT")]
    public int? CommentPoint { get; set; }

    [InverseProperty("Comments")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [ForeignKey("UserId")]
    [InverseProperty("Comments")]
    public virtual AspNetUser User { get; set; } = null!;
}
