using System;
using System.Collections.Generic;

namespace CostCalculator.Core
{
    public class Job
    {
        public bool ExtraMargin { get; set; }

        public IEnumerable<PrintItem> Items { get; set; }
    }
}
