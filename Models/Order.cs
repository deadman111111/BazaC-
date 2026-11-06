using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Order
{
    public int Idorders { get; set; }

    public int? Iduser { get; set; }

    public DateTime Dateorder { get; set; }

    public virtual User? IduserNavigation { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
