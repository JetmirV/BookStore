using System;
using System.Collections.Generic;

namespace Domain.Entities.AccountApi;

public partial class Address
{
    public int Id { get; set; }

    public string Address1 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Country { get; set; }
}
