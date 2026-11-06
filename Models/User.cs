using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string Surname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int? Idrole { get; set; }

    public string? Login { get; set; }

    public virtual Role? IdroleNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
