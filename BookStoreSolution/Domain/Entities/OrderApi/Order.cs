﻿using System;
using System.Collections.Generic;

namespace Domain.Entities.OrderApi;

public partial class Order
{
    public int Id { get; set; }

    public int Status { get; set; }

    public int ClientId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }
}
