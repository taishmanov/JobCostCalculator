using System;
using System.Collections.Generic;
using System.Text;

namespace CostCalculator.Core
{
    public class CompanyRates
    {
        public decimal SalesTax { get; set; } = 0.07M;
        public decimal BaseMargin { get; set; } = 0.11M;
        public decimal ExtraMargin { get; set; } = 0.05M;
    }
}
