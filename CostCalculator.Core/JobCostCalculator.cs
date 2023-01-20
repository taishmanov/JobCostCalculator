using System;
using System.Collections.Generic;
using System.Text;

namespace CostCalculator.Core
{
    public class JobCostCalculator
    {
        private readonly CompanyRates _companyRates;
        
        public JobCostCalculator(CompanyRates companyRates)
        {
            _companyRates = companyRates;
        }

        public CalculatedJob Calculate(Job job)
        {
            var total = 0M;
            List<CalculatedPrintItem> calculatedPrintItems = new List<CalculatedPrintItem>();

            foreach (var item in job.Items)
            {
                var tax = 0m;
                if (!item.Exempt)
                {
                    tax = item.Price * _companyRates.SalesTax;
                }
                var itemFinalPrice = item.Price + tax;
                
                calculatedPrintItems.Add(
                    new CalculatedPrintItem(item.Name, item.Price, item.Exempt, Math.Round(itemFinalPrice, 2)));

                var margin = item.Price * _companyRates.BaseMargin;
                if (job.ExtraMargin)
                {
                    margin = item.Price * (_companyRates.BaseMargin + _companyRates.ExtraMargin);
                }
                total += itemFinalPrice + margin;
            }

            // round to nearest cent
            total = Math.Round(total / 2, 2, MidpointRounding.AwayFromZero) * 2;

            return new CalculatedJob(job.ExtraMargin, calculatedPrintItems, total);
        }
    }
}
