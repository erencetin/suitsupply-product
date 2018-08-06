using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuitSupplyAssessment.ProductCatalog.Model;
using SuitSupplyAssessment.ProductCatalog.DataAccess;
namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class RemoveProduct : IRemoveProduct
    {
        private ProductContext productContext;
        public RemoveProduct()
        {
            productContext = ProductContext.GetContextInstance();
        }
        public Product InputArgument { get; set; }
        public bool OutputArgument { get; set; }

        public void Execute()
        {
            productContext.Products.Remove(this.InputArgument);
            this.OutputArgument = true;

        }

    }
}
