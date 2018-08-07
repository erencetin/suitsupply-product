using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuitSupplyAssessment.ProductCatalog.WebUI.Models
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}