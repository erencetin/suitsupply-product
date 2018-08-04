using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public interface IBusiness<Tinput,Toutput>
    {
        Tinput InputArgument { get; set; }
        Toutput OutputArgument { get; set; }
        void Execute();

    }
}
