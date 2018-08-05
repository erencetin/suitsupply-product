using SuitSupplyAssessment.ProductCatalog.DataAccess;
using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class GetProduct : IBusiness<Func<Product,bool>, List<Product>>
    {
        private const string ProductNotFound = "Product has not been found";
        private ProductContext productContext;
        public GetProduct()
        {
            productContext = ProductContext.GetContextInstance();
        }
        public Func<Product,bool> InputArgument { get ; set ; }
        public List<Product> OutputArgument { get; set; }

        public void Execute()
        {
            var productList = productContext.Products.Where(InputArgument);
            this.OutputArgument = productList.ToList<Product>();
        }
    }
}
