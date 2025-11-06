using System;
using System.Collections.Generic;

namespace MeasurePerformanceORM.Models
{
    public partial class T01
    {
        public T01()
        {
            T02s = new HashSet<T02>();
        }

        public int T01f01 { get; set; }
        public string? T01f02 { get; set; }
        public string? T01f03 { get; set; }

        public virtual ICollection<T02> T02s { get; set; }
    }
}
