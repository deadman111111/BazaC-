using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Size
{
    public int Idsize { get; set; }

    public double Name { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Stockitem> Stockitems { get; set; } = new List<Stockitem>();
}
