using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuitSupplyAssessment.ProductCatalog.Model;
using SuitSupplyAssessment.ProductCatalog.DataAccess;

namespace SuitSupplyAssessment.ProductCatalog.UnitTest
{
    [TestFixture]
    public class DatabaseTests
    {
        ProductContext productContext;
        [OneTimeSetUp]
        public void Init()
        {
            productContext = ProductContext.GetContextInstance();
         //   Database.SetInitializer<ProductContext>(null);
        }
        [Test]
        public void ShouldAddNewProduct()
        {
            productContext.Products.Add(GenerateNewProductObject());
            productContext.SaveChanges();
        }
        [Test]
        public void ShouldProductBeUpdated()
        {
            productContext.Products.Add(GenerateNewProductObject());
            productContext.SaveChanges();
            var product = productContext.Products.Where<Product>(p => p.Code == "product-1").First();
            product.Name = "Test product";
            productContext.SaveChanges();
            var updatedProduct = productContext.Products.Where<Product>(p => p.Code == "product-1").First();
            Assert.IsTrue(updatedProduct.Name == "Test product");
        }
        [Test]
        public void ShouldRetrieveProduct()
        {
            var retrievedProductList = productContext.Products.Where<Product>(p => p.Code == "product-1");
            Assert.IsTrue(retrievedProductList.Count() > 0);
        }

        [OneTimeTearDown]
        public void AfterExecution()
        {
            productContext.Products.RemoveRange(productContext.Products);
            productContext.SaveChanges();
        }
        private Product GenerateNewProductObject()
        {
            Product product = new Product();
            product.Code = "product-1";
            product.Id = 1;
            product.LastUpdated = DateTime.Now;
            product.Name = "Sample product";
            product.Photo = "productPhoto.png";
            return product;
        }
    }
}