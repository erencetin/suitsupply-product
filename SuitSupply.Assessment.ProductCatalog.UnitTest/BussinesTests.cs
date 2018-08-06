using NUnit.Framework;
using SuitSupplyAssessment.ProductCatalog.Business;
using SuitSupplyAssessment.ProductCatalog.Model;
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
            Product product1 = new Product { Code = "product code 1", Name = "product name 1", Price = 111 };
            createProduct.InputArgument = product1;
            createProduct.Execute();
            Assert.IsNotNull(createProduct.OutputArgument);


        }
        [Test]
        public void ShouldPreventCreateProductWithSameProductCode()
        {
            try
            {
                CreateProduct createProduct = new CreateProduct();
                Product product1 = new Product { Code = "product code 1", Name = "product name 1", Price = 111 };
                createProduct.InputArgument = product1;
                createProduct.Execute();
                CommitDatabaseChanges.Commit();
                Product product2 = new Product { Code = "product code 1", Name = "Should be prevented", Price = 34 };
                createProduct.InputArgument = product2;
                createProduct.Execute();
                Assert.Fail("There is something wrong! It shouldn't create a product with same product code.");

            }
            catch (DuplicateProductException)
            {

                Assert.Pass();
            }

        }
        [TestCase(-115)]
        [TestCase(0)]

        public void ShouldPreventProductCreateWithZeroOrNegativePrice(decimal price)
        {
            try
            {
                CreateProduct createProduct = new CreateProduct();
                Product product1 = new Product { Code = "product code 1", Name = "product name 1", Price = price };
                createProduct.InputArgument = product1;
                createProduct.Execute();
                Assert.Fail("Product creation has been failed because of inconvenient price");
            }
            catch (ProductPriceValidationException)
            {

                Assert.Pass();
            }

        }
        [Test]
        public void ShouldRemoveProduct()
        {
            var createdProduct = CreateNewProduct();
            CommitDatabaseChanges.Commit();
            RemoveProduct removeProdct = new RemoveProduct();
            removeProdct.InputArgument = createdProduct;
            removeProdct.Execute();
            CommitDatabaseChanges.Commit();
            Assert.IsTrue(removeProdct.OutputArgument);

        }
        [Test]
        public void ShouldUpdateExistentProduct()
        {

            var createdProduct = CreateNewProduct();
            UpdateProduct updateProduct = new UpdateProduct();          
            createdProduct.Name = "Updated";
            updateProduct.InputArgument = createdProduct;
            updateProduct.Execute();
            CommitDatabaseChanges.Commit();
            GetProduct getProduct = new GetProduct();
            getProduct.InputArgument = p => p.Name == "Updated";
            getProduct.Execute();
            Assert.IsTrue(getProduct.OutputArgument.Count > 0);
                
        }
        [Test]
        public void ShouldPreventUpdateWithSameProductCode()
        {
            var createdProduct = CreateNewProduct();
            CommitDatabaseChanges.Commit();
            var createAnotherProduct = CreateNewProduct("product code 2");
            CommitDatabaseChanges.Commit();
            createAnotherProduct.Code = "product code 1";
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.InputArgument = createAnotherProduct;
            try
            {
                updateProduct.Execute();
                Assert.Fail("Existed product code cannot be updated.");
            }
            catch (DuplicateProductException)
            {
                Assert.Pass();
                
            }

        }
        [Test]
        public void ShouldPreventUpdateWithInconvenientPrice()
        {
            var createdProduct = CreateNewProduct("product code 1");
            CommitDatabaseChanges.Commit();
            UpdateProduct updateProduct = new UpdateProduct();
            createdProduct.Price = 0;
            updateProduct.InputArgument = createdProduct;
            try
            {
                updateProduct.Execute();
                Assert.Fail("Product price should be greater than zero.");
            }
            catch (ProductPriceValidationException)
            {
                Assert.Pass();

            }

        }
        [TearDown]
        public void CleanChanges()
        {
            GetProduct getProduct = new GetProduct();
            getProduct.InputArgument = p => p.Code.Contains("product code");
            getProduct.Execute();
            if (getProduct.OutputArgument != null)
            {
                foreach (var item in getProduct.OutputArgument)
                {
                    RemoveProduct removeProduct = new RemoveProduct();
                    removeProduct.InputArgument = item;
                    removeProduct.Execute();
                }

            }
            CommitDatabaseChanges.Commit();
        }
        private Product CreateNewProduct(string productCode = "product code 1",decimal productPrice = 444)
        {
            CreateProduct createProduct = new CreateProduct();
            Product product1 = new Product { Code = productCode, Name = "product name 1", Price = productPrice };
            createProduct.InputArgument = product1;
            createProduct.Execute();
            return createProduct.OutputArgument;
        }

    }
}
