using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Harmic.Models;

public partial class TbRole
{
    [Key]
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbAccount> TbAccounts { get; set; } = new List<TbAccount>();
}
