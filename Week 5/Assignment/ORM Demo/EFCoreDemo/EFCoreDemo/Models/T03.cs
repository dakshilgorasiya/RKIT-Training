using System;
using System.Collections.Generic;

namespace EFCoreDemo.Models;

public partial class T03
{
    public int? T03f01 { get; set; }

    public DateOnly? T03f02 { get; set; }

    public decimal T03f03 { get; set; }

    public virtual T01? T03f01Navigation { get; set; }
}
