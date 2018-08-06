using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuitSupplyAssessment.ProductCatalog.Business;
using SuitSupplyAssessment.ProductCatalog.Model;
using SuitSupplyAssessment.ProductCatalog.WebUI.Models;

namespace SuitSupplyAssessment.ProductCatalog.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IGetProduct getProduct;
        ICreateProduct createProduct;
        IUpdateProduct updateProduct;
        IRemoveProduct removeProduct;
        IValidateProductPrice validateProductPrice;
        IConfirmProductPrice confirmProductPrice;
        public ProductController(IGetProduct getProduct, ICreateProduct createProduct, IUpdateProduct updateProduct, IRemoveProduct removeProduct, IValidateProductPrice validateProductPrice, IConfirmProductPrice confirmProductPrice)
        {
            this.getProduct = getProduct;
            this.createProduct = createProduct;
            this.updateProduct = updateProduct;
            this.removeProduct = removeProduct;
            this.validateProductPrice = validateProductPrice;
            this.confirmProductPrice = confirmProductPrice;
        }
        // GET: Product
        public ActionResult Index()
        {
            getProduct.InputArgument = p => true;
            getProduct.Execute();
            return View(getProduct.OutputArgument);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            getProduct.InputArgument = p => p.Id == id;
            getProduct.Execute();
            return View(getProduct.OutputArgument.Single());
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(CreateProductViewModel productViewModel)
        {

            if (productViewModel.File != null && productViewModel.File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(productViewModel.File.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                productViewModel.File.SaveAs(path);
                productViewModel.ProductObject.Photo = fileName;
                createProduct.InputArgument = productViewModel.ProductObject;
                createProduct.Execute();
                CommitDatabaseChanges.Commit();
            }


            return RedirectToAction("Index");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            getProduct.InputArgument = p => p.Id == id;
            getProduct.Execute();
            return View(getProduct.OutputArgument.Single());

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {

            getProduct.InputArgument = p => p.Id == id;
            getProduct.Execute();
            var retrievedProduct = getProduct.OutputArgument.Single();
            retrievedProduct.Code = product.Code;
            retrievedProduct.Name = product.Name;
            retrievedProduct.Photo = product.Photo;
            retrievedProduct.Price = product.Price;
            updateProduct.InputArgument = retrievedProduct;
            updateProduct.Execute();
            CommitDatabaseChanges.Commit();
            return RedirectToAction("Index");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            getProduct.InputArgument = p => p.Id == id;
            getProduct.Execute();
            return View(getProduct.OutputArgument.Single());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product prodoct)
        {

            getProduct.InputArgument = p => p.Id == id;
            getProduct.Execute();
            removeProduct.InputArgument = getProduct.OutputArgument.Single();
            removeProduct.Execute();
            CommitDatabaseChanges.Commit();
            return RedirectToAction("Index");

        }
    }
}
