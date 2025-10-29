using System;
using System.Collections.Generic;

namespace EFCoreDemo.Models;

public partial class T01
{
    public int T01f01 { get; set; }

    public string T01f02 { get; set; } = null!;

    public int? T01f03 { get; set; }

    public decimal T01f04 { get; set; }

    public virtual T02? T01f03Navigation { get; set; }
}
