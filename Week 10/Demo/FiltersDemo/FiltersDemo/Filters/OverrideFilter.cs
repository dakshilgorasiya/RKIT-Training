using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace FiltersDemo.Filters
{
    public class OverrideFilter : Attribute, IOverrideFilter
    {
        public Type FiltersToOverride => typeof(IActionFilter);

        public bool AllowMultiple => false;
    }
}