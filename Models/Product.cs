using System;
using System.Collections.Generic;

namespace DemoDatabaseUsingEntityFramework.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
