using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wood.Models;

[Index("BookId", Name = "IX_OrderItems_BookId")]
[Index("OrderId", Name = "IX_OrderItems_OrderId")]
public partial class OrderItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Order_id")]
    public int OrderId { get; set; }

    [Column("Book_id")]
    public int BookId { get; set; }

    public int Quantity { get; set; }

    [Column("Price_at_purchase")]
    public double PriceAtPurchase { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("OrderItems")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;
}
