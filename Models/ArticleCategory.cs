using System;
using System.Collections.Generic;

namespace EShopSilicon.Models;

public partial class ArticleCategory
{
    public int ArticleCategoryId { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? CreateBy { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual Account? CreateByNavigation { get; set; }
}
