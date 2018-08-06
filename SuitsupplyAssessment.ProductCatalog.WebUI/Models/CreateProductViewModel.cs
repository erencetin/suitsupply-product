using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuitSupplyAssessment.ProductCatalog.WebUI.Models
{
    public class CreateProductViewModel
    { 
        public Product ProductObject { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}