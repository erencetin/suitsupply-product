using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    internal class BusinessHelper
    {
        internal static bool ValidateInputArgument<T>(T inputObject)
        {
            return inputObject != null;
        }

    }
}
