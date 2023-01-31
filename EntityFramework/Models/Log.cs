using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Log
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime TimeStamp { get; set; }

    public string Ipaddress { get; set; } = null!;

    public string? ClientInfo { get; set; }
}
