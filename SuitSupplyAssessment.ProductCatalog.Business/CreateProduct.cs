using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuitSupplyAssessment.ProductCatalog.Model;
using SuitSupplyAssessment.ProductCatalog.DataAccess;
namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class CreateProduct : IBusiness<Product, Product>
    {
        private ProductContext productContext;
        private GetProduct getProduct;
        public CreateProduct()
        {
            productContext = new ProductContext();
            getProduct = new GetProduct();
        }
        public Product InputArgument { get; set; }
        public Product OutputArgument { get; set; }

        public void Execute()
        {
            CheckProductExists();


        }
        private void CheckProductExists()
        {
            getProduct.InputArgument = p => p.Code == this.InputArgument.Code;
            getProduct.Execute();
            if (getProduct.OutputArgument != null && getProduct.OutputArgument.Count() > 0)
                throw new  DuplicateProductException();
        }
        private void ValidatePrice()
        {

        }
    }
}
