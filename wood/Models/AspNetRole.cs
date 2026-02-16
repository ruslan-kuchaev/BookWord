using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wood.Models;

[Index("NormalizedName", Name = "RoleNameIndex")]
public partial class AspNetRole
{
    [Key]
    public string Id { get; set; } = null!;

    public string? ConcurrencyStamp { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
