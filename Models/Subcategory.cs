using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Subcategory
{
    public int Idsubcategories { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
