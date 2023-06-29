using System;
using System.Collections.Generic;

namespace Domain.Entities.CartApi;

public partial class CartItemLog
{
    public int Id { get; set; }

    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public DateTime InsertDateTime { get; set; }
}
