using System;
using System.Collections.Generic;

namespace Domain.Entities.BookStore;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string Authors { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Picture { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }
}
