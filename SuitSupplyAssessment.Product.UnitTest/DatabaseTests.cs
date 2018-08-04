using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuitSupplyAssessment.ProductCatalog.DataModel;
namespace SuitSupplyAssessment.Product.UnitTest
{
    [TestFixture]
    public class DatabaseTests
    {
        ProductContext productContext;
        [OneTimeSetUp]
        public void Init()
        {
           
        }
        [Test]
        public void ShouldAddNewProduct()
        {
            productContext = new ProductContext();
            ProductCatalog.DataModel.Product product = new ProductCatalog.DataModel.Product();
            product.Code = "product-1";
            product.Id = 1;
            product.LastUpdated = DateTime.Now;
            product.Name = "Sample product";
            product.Photo = "productPhoto.png";
            productContext.Products.Add(product);
            
        }
    }
}
