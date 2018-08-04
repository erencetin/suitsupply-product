using NUnit.Framework;
using SuitSupplyAssessment.ProductCatalog.Business;
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
                Code = "Product-3",
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
        bool[] priceValidationExpectedResults = { false, false, true, true,false,false };
        bool[] priceConfirmatinExceptedResults = { false, false, false, true,false, false };
        [Test]
        public void ShouldHaveValidPrice() {
            ValidateProductPrice validateProductPrice = new ValidateProductPrice();
            for (int i = 0; i < objectSource.Length; i++)
            {
                validateProductPrice.InputArgument = objectSource[i];
                validateProductPrice.Execute();
                Assert.AreEqual(validateProductPrice.OutputArgument,priceValidationExpectedResults[i]);
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
                Assert.AreEqual(confirmProductPrice.OutputArgument, priceConfirmatinExceptedResults[i]);
            }
        }

    }
}
