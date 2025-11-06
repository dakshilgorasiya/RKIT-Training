using System;
using System.Collections.Generic;

namespace MeasurePerformanceORM.Models
{
    public partial class T02
    {
        public int T02f01 { get; set; }
        public string T02f02 { get; set; } = null!;
        public string T02f03 { get; set; } = null!;
        public string T02f04 { get; set; } = null!;
        public DateOnly T02f05 { get; set; }
        public string T02f06 { get; set; } = null!;
        public decimal T02f07 { get; set; }
        public int? T02f08 { get; set; }

        public virtual T01? T02f08Navigation { get; set; }
    }
}
