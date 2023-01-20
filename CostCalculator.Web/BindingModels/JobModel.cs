using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostCalculator.Web.BindingModels
{
    public class JobModel
    {
        public bool ExtraMargin { get; set; }

        public List<PrintItemModel> Items { get; set; }
    }
}
