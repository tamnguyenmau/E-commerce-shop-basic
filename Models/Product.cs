using System;
using System.Collections.Generic;

namespace EShopSilicon.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Title { get; set; }

    public string? Decs { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? Condition { get; set; }

    public string? DayProject { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }

    public string? DetailInfo { get; set; }

    public string? Content { get; set; }

    public int? ProductCategoryId { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }

    public virtual ProductCategory? ProductCategory { get; set; }
}
