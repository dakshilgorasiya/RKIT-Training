using System;
using System.Collections.Generic;

namespace EFCoreDemo.Models;

public partial class EmployeeSalarySummary
{
    public int T01f01 { get; set; }

    public string T01f02 { get; set; } = null!;

    public string? T02f02 { get; set; }

    public decimal T01f04 { get; set; }

    public decimal CoalesceSumT03f030 { get; set; }

    public long CountT03f03 { get; set; }
}
