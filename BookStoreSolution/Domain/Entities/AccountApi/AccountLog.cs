using System;
using System.Collections.Generic;

namespace Domain.Entities.AccountApi;

public partial class AccountLog
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int AddressId { get; set; }

    public DateTime InsertDateTime { get; set; }
}
