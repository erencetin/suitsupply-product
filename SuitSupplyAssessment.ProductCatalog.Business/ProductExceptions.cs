using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(): base("Product has not been found")
        {

        }
    }
    public class DuplicateProductException : Exception
    {
       public DuplicateProductException() : base("This product already exists in database. Please enter another product code.")
       {

       }
        
    }

}
