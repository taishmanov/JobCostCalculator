using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostCalculator.Web.ViewModels
{
    public class CalculatedJobModel
    {
        public bool ExtraMargin { get; set; }

        public IEnumerable<CalculatedPrintItemModel> Items { get; set; } 

        public decimal Total { get; set; }
    }
}
