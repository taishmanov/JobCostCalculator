using CostCalculator.Core;
using CostCalculator.Web.BindingModels;
using CostCalculator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CostCalculator.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly JobCostCalculator _jobCostCalculator;

        public CalculatorController(ILogger<CalculatorController> logger, JobCostCalculator jobCostCalculator)
        {
            _logger = logger;
            _jobCostCalculator = jobCostCalculator;
        }

        [HttpPost]
        [Route("calculate-job")]
        public CalculatedJobModel CalculateJobs(JobModel jobModel)
        {
            var job = MapToCore(jobModel);

            var calculatedJob = _jobCostCalculator.Calculate(job);

            return MapToViewModel(calculatedJob);
        }

        #region Mappers - AutoMapper could be used

        private Job MapToCore(JobModel jobModel)
        {
            return new Job()
            {
                ExtraMargin = jobModel.ExtraMargin,
                Items = jobModel.Items.Select(it => MapToCore(it))
            };
        }

        private PrintItem MapToCore(PrintItemModel jobModel)
        {
            return new PrintItem()
            {
                Name = jobModel.Name,
                Exempt = jobModel.Exempt,
                Price = jobModel.Price
            };
        }

        private CalculatedJobModel MapToViewModel(CalculatedJob calculatedJob)
            => new CalculatedJobModel()
            {
                ExtraMargin = calculatedJob.ExtraMargin,
                Total = calculatedJob.Total,
                Items = calculatedJob.Items.Select(it => MapToViewModel(it))
            };

        private CalculatedPrintItemModel MapToViewModel(CalculatedPrintItem calculatedPrintItem)
            => new CalculatedPrintItemModel()
            {
                Name = calculatedPrintItem.Name,
                Exempt = calculatedPrintItem.Exempt,
                Price = calculatedPrintItem.Price,
                FinalPrice = calculatedPrintItem.FinalPrice
            };

        #endregion
    }
}
