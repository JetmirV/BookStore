using System;
using System.Collections.Generic;

namespace Domain.Entities.AccountApi;

public partial class GeneralLog
{
    public int Id { get; set; }

    public string LogType { get; set; } = null!;

    public string? LogData { get; set; }

    public DateTime InsertDateTime { get; set; }
}
