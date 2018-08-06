using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class ConfirmProductPrice : IConfirmProductPrice
    {
        public Product InputArgument { get; set; }
        public bool OutputArgument { get; set; }

        public void Execute()
        {
            OutputArgument = InputArgument?.Price > 999;
        }
    }
}
