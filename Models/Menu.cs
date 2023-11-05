using System;
using System.Collections.Generic;

namespace EShopSilicon.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string? Title { get; set; }

    public string? Url { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }
}
