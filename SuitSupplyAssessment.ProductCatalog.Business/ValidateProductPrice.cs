using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuitSupplyAssessment.ProductCatalog.Model;
using SuitSupplyAssessment.ProductCatalog.DataAccess;
namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class ValidateProductPrice : IValidateProductPrice
    {
        public ValidateProductPrice()
        {
            
        }
        public Product InputArgument { get; set; }
        public bool OutputArgument { get; set; }

        public void Execute()
        {
            OutputArgument = InputArgument?.Price > 0;

        }
       
    }
}
