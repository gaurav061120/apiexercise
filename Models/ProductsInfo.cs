using System;
using System.Collections.Generic;

namespace ProductsApi.Models;

public partial class ProductsInfo
{
    public int Pid { get; set; }

    public decimal? Pprice { get; set; }

    public int? Cid { get; set; }

    public string? Pname { get; set; }

    public DateTime? Pmdate { get; set; }

    public virtual CompanysInfo? CidNavigation { get; set; }
}
