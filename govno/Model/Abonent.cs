using System;
using System.Collections.Generic;

namespace govno.Model;

public partial class Abonent
{
    public int Id { get; set; }

    public string? Lastname { get; set; }

    public string? Name { get; set; }

    public string? Middlename { get; set; }

    public string? Address { get; set; }

    public string? PostalNumber { get; set; }
}
