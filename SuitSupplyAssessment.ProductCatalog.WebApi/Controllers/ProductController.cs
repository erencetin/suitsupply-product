using SuitSupplyAssessment.ProductCatalog.Business;
using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuitSupplyAssessment.ProductCatalog.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ICreateProduct createProduct;
        private readonly IGetProduct getProduct;
        private readonly IUpdateProduct updateProduct;
        private readonly IRemoveProduct removeProduct;
        public ProductController(ICreateProduct createProduct, IGetProduct getProduct, IUpdateProduct updateProduct,IRemoveProduct removeProduct)
        {
            this.createProduct = createProduct;
            this.getProduct = getProduct;
            this.updateProduct = updateProduct;
            this.removeProduct = removeProduct;
        }
        // GET api/product
        public List<Product> Get()
        {
            getProduct.InputArgument = p => true;
            getProduct.Execute();
            return getProduct.OutputArgument;

        }

        // GET api/product/5
        public List<Product> Get(int id)
        {
            getProduct.InputArgument = p => p.Id == id;
            getProduct.Execute();
            return getProduct.OutputArgument;
        }

        [HttpPost]
        public void Create([FromBody]Product product)
        {
            this.createProduct.InputArgument = product;
            this.createProduct.Execute();
            CommitDatabaseChanges.Commit();
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]Product product)
        {
            this.getProduct.InputArgument = p => p.Id == id;
            this.getProduct.Execute();
            var retrievedProduct = getProduct.OutputArgument.Single();
            if (retrievedProduct != null)
            {
                retrievedProduct.Code = product.Code;
                retrievedProduct.Name = product.Name;
                retrievedProduct.Photo = product.Photo;
                retrievedProduct.Price = product.Price;
                this.updateProduct.InputArgument = retrievedProduct;
                this.updateProduct.Execute();
                CommitDatabaseChanges.Commit();
            }
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
            this.getProduct.InputArgument = p => p.Id == id;
            this.getProduct.Execute();
            var retrievedProduct = getProduct.OutputArgument.Single();
            if (retrievedProduct != null)
            {
                this.removeProduct.InputArgument = retrievedProduct;
                this.removeProduct.Execute();
                CommitDatabaseChanges.Commit();
            }
        }
    }
}
