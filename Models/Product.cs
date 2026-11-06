using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Product
{
    public int Idproducts { get; set; }

    public int? Idcategories { get; set; }

    public string Name { get; set; } = null!;

    public int? Idmanufacture { get; set; }

    public int? Idsubcategories { get; set; }

    public string Picture { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Composition { get; set; } = null!;

    public int Price { get; set; }

    public virtual Category? IdcategoriesNavigation { get; set; }

    public virtual Manufacture? IdmanufactureNavigation { get; set; }

    public virtual Subcategory? IdsubcategoriesNavigation { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Stockitem> Stockitems { get; set; } = new List<Stockitem>();
}
