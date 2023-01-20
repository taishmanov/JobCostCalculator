using System;
using System.Collections.Generic;
using System.Text;

namespace CostCalculator.Core
{
    public class CalculatedPrintItem
    {
        public CalculatedPrintItem(string name, decimal price, bool exempt, decimal finalPrice)
        {
            Name = name;
            Price = price;
            Exempt = exempt;
            FinalPrice = finalPrice;
        }

        public string Name { get; }

        public decimal Price { get; }

        public bool Exempt { get; }

        public decimal FinalPrice { get; }

    }
}
