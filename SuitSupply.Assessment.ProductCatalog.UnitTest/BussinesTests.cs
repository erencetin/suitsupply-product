using NUnit.Framework;
using SuitSupplyAssessment.ProductCatalog.Business;
using SuitSupplyAssessment.ProductCatalog.DataAccess;
using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.UnitTest
{
    [TestFixture]
    public class ProductBussinesTests
    {
        Product[] objectSource = new Product[] {
            new Product{
                Code = "Product-1",
                Name = "Product name 1",
                Price = -116
            },
             new Product{
                Code = "Product-2",
                Name = "Product name 2",
                Price = 0
            },
            new Product{
                Code = "Product-2",
                Name = "Product name 3",
                Price = 800
            },
             new Product{
                Code = "Product-4",
                Name = "Product name 4",
                Price = 1650
            },
            null,
            new Product{
                Code = "Product-6",
                Name = "Product name 6"
            }

        };
        bool[] priceValidationExpectedResults = { false, false, true, true, false, false };
        bool[] priceConfirmatinExpectedResults = { false, false, false, true, false, false };
        
        [Test]
        public void ShouldHaveValidPrice()
        {
            ValidateProductPrice validateProductPrice = new ValidateProductPrice();
            for (int i = 0; i < objectSource.Length; i++)
            {
                validateProductPrice.InputArgument = objectSource[i];
                validateProductPrice.Execute();
                Assert.AreEqual(validateProductPrice.OutputArgument, priceValidationExpectedResults[i]);
            }
        }
        [Test]
        public void ShouldCheckPriceConfirmationNecessity()
        {
            ConfirmProductPrice confirmProductPrice = new ConfirmProductPrice();
            for (int i = 0; i < objectSource.Length; i++)
            {
                confirmProductPrice.InputArgument = objectSource[i];
                confirmProductPrice.Execute();
                Assert.AreEqual(confirmProductPrice.OutputArgument, priceConfirmatinExpectedResults[i]);
            }
        }
        [Test]
        public void ShouldCreateNewProduct()
        {

            CreateProduct createProduct = new CreateProduct();
            Product product1 = new Product { Code = "product code 1" , Name = "product name 1", Price = 111 };
            createProduct.InputArgument = product1;
            createProduct.Execute();
            Assert.IsNotNull(createProduct.OutputArgument);
            
            
        }
        [Test]
        public void ShouldPreventCreateProductWithSameProductCode()
        {
            CreateProduct createProduct = new CreateProduct();
            Product product2 = new Product { Code = "Product code 1", Name = "Should be prevented", Price = 34 };
            createProduct.InputArgument = product2;
            try
            {
                createProduct.Execute();
                Assert.Fail("There is something wrong! It shouldn't create a product with same product code.");

            }
            catch (DuplicateProductException)
            {

                Assert.Pass();
            }
             
        }

        [TearDown]
        public void CleanChanges()
        {
            GetProduct getProduct = new GetProduct();
            getProduct.InputArgument = p => p.Code.Contains("Product code");
            getProduct.Execute();
            RemoveProduct removeProduct = new RemoveProduct();
            removeProduct.InputArgument = getProduct.OutputArgument.First();
            removeProduct.Execute();
            //foreach (var item in objectSource)
            //{
            //    removeProduct.InputArgument = item;
            //    removeProduct.Execute();
            //}
        }

    }
}
