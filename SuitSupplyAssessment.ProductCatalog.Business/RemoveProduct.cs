using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuitSupplyAssessment.ProductCatalog.Model;
using SuitSupplyAssessment.ProductCatalog.DataAccess;
namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class RemoveProduct : IBusiness<Product, Product>
    {
        private ProductContext productContext;
        private GetProduct getProduct;
        public RemoveProduct()
        {
            productContext = new ProductContext();
            getProduct = new GetProduct();
        }
        public RemoveProduct(ProductContext productContext)
        {
            this.productContext = productContext;
            getProduct = new GetProduct();
        }
        public Product InputArgument { get; set; }
        public Product OutputArgument { get; set; }

        public void Execute()
        {
           this.OutputArgument = productContext.Products.Remove(InputArgument);
            productContext.SaveChanges();

        }

    }
}
