using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Manufacture
{
    public int Idmanufacture { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
