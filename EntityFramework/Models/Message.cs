using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Message
{
    public int Id { get; set; }

    public int SenderUserId { get; set; }

    public int RecipientUserId { get; set; }

    public DateTime TimeStamp { get; set; }

    public string MessageBody { get; set; } = null!;
}
