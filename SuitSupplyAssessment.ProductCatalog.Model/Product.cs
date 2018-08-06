using System;
using System.ComponentModel.DataAnnotations;

namespace SuitSupplyAssessment.ProductCatalog.Model
{
    public class Product
    {
  
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
       // [Range(0, int.MaxValue, ErrorMessage = "Please enter a price bigger than {1}")]
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
