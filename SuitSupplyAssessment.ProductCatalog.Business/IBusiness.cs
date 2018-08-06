using SuitSupplyAssessment.ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public interface IBusiness<Tinput, Toutput>
    {
        Tinput InputArgument { get; set; }
        Toutput OutputArgument { get; set; }
        void Execute();

    }
    public interface ICreateProduct : IBusiness<Product, Product>
    {

    }
    public interface IGetProduct : IBusiness<Func<Product, bool>, List<Product>>
    {

    }
    public interface IRemoveProduct : IBusiness<Product, bool>
    {

    }
    public interface IUpdateProduct : IBusiness<Product, bool>
    {

    }
    public interface IConfirmProductPrice : IBusiness<Product, bool>
    {

    }
    public interface IValidateProductPrice : IBusiness<Product, bool>
    {

    }
}
