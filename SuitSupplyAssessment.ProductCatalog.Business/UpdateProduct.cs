using SuitSupplyAssessment.ProductCatalog.DataAccess;
using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class UpdateProduct : IBusiness<Product, bool>
    {
        private ProductContext productContext;
        public Product InputArgument { get; set; }
        public bool OutputArgument { get; set; }
        public UpdateProduct()
        {
            productContext = new ProductContext();
        }
        public UpdateProduct(ProductContext productContext)
        {
            this.productContext = productContext;
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
                if (getProduct.OutputArgument?.Count>0)
                {
                    this.InputArgument.LastUpdated = DateTime.Now;
                    productContext.SaveChanges();
                }
                else
                {
                    throw new DuplicateProductException();
                }
            }
            else
            {
                throw new ProductPriceValidationException();
            }
        }
    }
}
