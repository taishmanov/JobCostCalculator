using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostCalculator.Web.ViewModels
{
    public class CalculatedPrintItemModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Exempt { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
