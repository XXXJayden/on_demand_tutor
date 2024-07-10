using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class PasswordResetToken
{
    public int TokenId { get; set; }

    public string Token { get; set; } = null!;

    public int UserId { get; set; }

    public string UserType { get; set; } = null!;

    public DateTime ExpirationDate { get; set; }

    public bool IsUsed { get; set; }

    public DateTime CreatedDate { get; set; }
}
