using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wood.Models;

[Index("OrderStatus", Name = "IX_Orders_Status")]
[Index("UserId", Name = "IX_Orders_UserId")]
public partial class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("User_id")]
    public string UserId { get; set; } = null!;

    [Column("Order_Date")]
    public DateTime OrderDate { get; set; } = DateTime.Today;

    [Column("Order_total_amount")]
    public decimal OrderTotalAmount { get; set; }

    [Column("Order_status")]
    public string OrderStatus { get; set; } = null!;

    public string? ShippingAddress { get; set; }

    public string? PhoneNumber { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual AspNetUser User { get; set; } = null!;
    
}
