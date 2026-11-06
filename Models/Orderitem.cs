using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Orderitem
{
    public int Idorderitems { get; set; }

    public int? Idorders { get; set; }

    public int? Idproducts { get; set; }

    public int Quantity { get; set; }

    public int? Idsize { get; set; }

    public virtual Order? IdordersNavigation { get; set; }

    public virtual Product? IdproductsNavigation { get; set; }

    public virtual Size? IdsizeNavigation { get; set; }
}
