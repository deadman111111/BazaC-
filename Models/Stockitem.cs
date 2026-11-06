using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Stockitem
{
    public int Idstockitems { get; set; }

    public int? Idproducts { get; set; }

    public int? Idsize { get; set; }

    public int Availablequantity { get; set; }

    public virtual Product? IdproductsNavigation { get; set; }

    public virtual Size? IdsizeNavigation { get; set; }
}
