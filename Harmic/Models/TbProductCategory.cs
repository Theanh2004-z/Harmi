using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Harmic.Models;

public partial class TbProductCategory
{
    [Key]
    public int CategoryProductId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public int? Position { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
