using System;
using System.Collections.Generic;

namespace ProductsApi.Models;

public partial class CompanysInfo
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public virtual ICollection<ProductsInfo> ProductsInfos { get; set; } = new List<ProductsInfo>();
}
