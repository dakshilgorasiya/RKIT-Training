using System;
using System.Collections.Generic;

namespace EFCoreDemo.Models;

public partial class T02
{
    public int T02f01 { get; set; }

    public string T02f02 { get; set; } = null!;

    public virtual ICollection<T01> T01s { get; set; } = new List<T01>();
}
