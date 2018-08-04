using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuitSupplyAssessment.ProductCatalog.DataModel;
namespace SuitSupplyAssesment.ProductCatalog.Business
{
    public interface IProductBusiness<IModel>
    {
        IModel InputObject { get; set; }
        IModel OutputObject { }
        void Execute();
    }
}
