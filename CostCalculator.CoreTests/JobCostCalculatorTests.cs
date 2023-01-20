using Microsoft.VisualStudio.TestTools.UnitTesting;
using CostCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostCalculator.Core.Tests
{
    [TestClass]
    public class JobCostCalculatorTests
    {
        private JobCostCalculator jobCostCalculator = new JobCostCalculator(new CompanyRates());

        [TestMethod]
        [DataRow(true, "0.00", "0.00")]
        [DataRow(true, "100.00", "100.00")]
        [DataRow(false, "100.00", "107.00")]
        public void CalculateTest_Item_ApplyTax(bool exempt, string priceStr, string finalPriceStr)
        {
            decimal price = decimal.Parse(priceStr);
            decimal finalPrice = decimal.Parse(finalPriceStr);

            Job job = new Job() 
            { 
                Items = new PrintItem[1] { new PrintItem() { Name = "Item1", Exempt = exempt, Price = price } } 
            };
            
            var result = jobCostCalculator.Calculate(job);

            Assert.AreEqual(finalPrice, result.Items.First().FinalPrice);
        }

        [TestMethod]
        [DataRow(false, true, "100.00", "111.00")]
        [DataRow(true, false, "100.00", "123.00")]
        [DataRow(true, true, "100.00", "116.00")]
        public void CalculateTest_Item_ApplyTax_And_Margin(bool extraMargin, bool exempt, string priceStr, string totalStr)
        {
            decimal price = decimal.Parse(priceStr);
            decimal totalPrice = decimal.Parse(totalStr);

            Job job = new Job() 
            { 
                ExtraMargin = extraMargin,
                Items = new PrintItem[1] { new PrintItem() { Name = "Item1", Exempt = exempt, Price = price } } 
            };
            
            var result = jobCostCalculator.Calculate(job);

            Assert.AreEqual(totalPrice, result.Total);
        }

        [TestMethod]
        public void CalculateTest_Total_Rounding()
        {
            Job job = new Job()
            {
                ExtraMargin = false,
                Items = new PrintItem[1]
                {
                    new PrintItem() { Name = "envelopes", Exempt = false, Price = 294.04M }
                }
            };

            var result = jobCostCalculator.Calculate(job);

            Assert.AreEqual(314.62M, result.Items.First(it => it.Name == "envelopes").FinalPrice);
            Assert.AreEqual(346.96M, result.Total);
        }

        [TestMethod]
        public void CalculateTest_MultipleItems_Mixed()
        {
            Job job = new Job()
            {
                ExtraMargin = true,
                Items = new PrintItem[2] 
                { 
                    new PrintItem() { Name = "envelopes", Price = 520.00M },
                    new PrintItem() { Name = "letterhead", Exempt = true, Price = 1983.37M }
                }
            };

            var result = jobCostCalculator.Calculate(job);

            Assert.AreEqual(556.40M, result.Items.First(it => it.Name == "envelopes").FinalPrice);
            Assert.AreEqual(1983.37M, result.Items.First(it => it.Name == "letterhead").FinalPrice);
            Assert.AreEqual(2940.30M, result.Total);
        }
    }
}