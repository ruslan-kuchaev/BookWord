using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wood.Models;

public partial class Book
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Category_id")]
    public int CategoryId { get; set; }

    [Column("Author_id")]
    public int AuthorId { get; set; }

    [Column("Book_name")]
    public string BookName { get; set; } = null!;

    public string? Publisher { get; set; }

    [Column("Book_price")]
    public int BookPrice { get; set; }

    [Column("Books_price_online")]
    public int? BooksPriceOnline { get; set; }

    [Column("Book_count", TypeName = "INT")]
    public int BookCount { get; set; }

    [Column("Comments_id")]
    public int? CommentsId { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Books")]
    public virtual Author Author { get; set; } = null!;

    [ForeignKey("CommentsId")]
    [InverseProperty("Books")]
    public virtual Comment? Comments { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
