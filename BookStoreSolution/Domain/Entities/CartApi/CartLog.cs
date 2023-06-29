using System;
using System.Collections.Generic;

namespace Domain.Entities.CartApi;

public partial class CartLog
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int CustomerId { get; set; }

    public DateTime InsertDateTime { get; set; }
}
