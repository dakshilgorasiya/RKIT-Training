using System;
using System.Collections.Generic;

namespace EFCoreDemo.Models;

public partial class T04
{
    public int? T04f01 { get; set; }

    public DateTime? T04f02 { get; set; }

    public decimal T04f03 { get; set; }

    public virtual T01? T04f01Navigation { get; set; }
}
