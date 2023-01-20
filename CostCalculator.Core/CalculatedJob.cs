using System;
using System.Collections.Generic;
using System.Text;

namespace CostCalculator.Core
{
    public class CalculatedJob
    {
        public CalculatedJob(bool extraMargin, IEnumerable<CalculatedPrintItem> items, decimal total)
        {
            ExtraMargin = extraMargin;
            Items = items;
            Total = total;
        }

        public bool ExtraMargin { get; }

        public IEnumerable<CalculatedPrintItem> Items { get; } // TODO readonly collection

        public decimal Total { get; }
    }
}
