using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostCalculator.Web.BindingModels
{
    public class PrintItemModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Exempt { get; set; }
    }
}
