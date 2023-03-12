using System;
using System.Collections.Generic;

namespace sunum2.Web.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public DateTimeOffset ProductCreateDate { get; set; }

    public string ProductImageUrl { get; set; } = null!;
}
