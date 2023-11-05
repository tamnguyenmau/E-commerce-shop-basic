using System;
using System.Collections.Generic;

namespace EShopSilicon.Models;

public partial class Gallery
{
    public int GalleryId { get; set; }

    public string? Title { get; set; }

    public string? Avatar { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }
}
