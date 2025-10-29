using System;
using System.Collections.Generic;

namespace EFCore.Models;

public partial class EmpDept
{
    public int T02f01 { get; set; }

    public string T02f02 { get; set; } = null!;

    public string T02f03 { get; set; } = null!;

    public string? T01f02 { get; set; }
}
