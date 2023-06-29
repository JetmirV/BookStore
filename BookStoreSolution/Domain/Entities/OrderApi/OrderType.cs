using System;
using System.Collections.Generic;

namespace Domain.Entities.OrderApi;

public partial class OrderType
{
    public int Id { get; set; }

    public string? Type { get; set; }
}
