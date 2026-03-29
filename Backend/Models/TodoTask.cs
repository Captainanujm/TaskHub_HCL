using System;
using System.Collections.Generic;

namespace TaskHub.Models;

public partial class Todotask
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
