using System;
using System.Collections.Generic;

namespace Domain.Entities.OrderApi;

public partial class OrderItemLog
{
    public int Id { get; set; }

    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public DateTime InsertDateTime { get; set; }
}
