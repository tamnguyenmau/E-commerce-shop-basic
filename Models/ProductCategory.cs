using System;
using System.Collections.Generic;

namespace EShopSilicon.Models;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
