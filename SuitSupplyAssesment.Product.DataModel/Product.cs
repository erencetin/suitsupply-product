using System;

namespace SuitSupplyAssessment.ProductCatalog.DataModel
{
    public class Product
    {
  
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal MyProperty { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
