using System;
using System.Collections.Generic;

namespace Domain.Entities.OrderApi;

public partial class OrderLog
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int Status { get; set; }

    public int ClientId { get; set; }

    public DateTime? InsertDateTime { get; set; }
}
