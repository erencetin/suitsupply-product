using SuitSupplyAssessment.ProductCatalog.DataAccess;
using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class UpdateProduct : IUpdateProduct
    {
        private ProductContext productContext;
        public Product InputArgument { get; set; }
        public bool OutputArgument { get; set; }
        public UpdateProduct()
        {
            productContext = ProductContext.GetContextInstance();
        }

        public void Execute()
        {
            ValidateProductPrice validateProductPrice = new ValidateProductPrice();
            validateProductPrice.InputArgument = this.InputArgument;
            validateProductPrice.Execute();
            if (validateProductPrice.OutputArgument)
            {
                GetProduct getProduct = new GetProduct();
                getProduct.InputArgument = p => p.Code == this.InputArgument.Code;
                getProduct.Execute();
                if (getProduct.OutputArgument?.Count>0 && getProduct.OutputArgument[0].Id != this.InputArgument.Id)
                {
                    throw new DuplicateProductException();
                }
                else
                {
                    this.InputArgument.LastUpdated = DateTime.Now;
                }
            }
            else
            {
                throw new ProductPriceValidationException();
            }
        }
    }
}
