using SuitSupplyAssessment.ProductCatalog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupplyAssessment.ProductCatalog.Business
{
    public class CommitDatabaseChanges
    {
        public static void Commit() {
            ProductContext.GetContextInstance().SaveChanges();
        }
        public static void Rollback()
        {
            ProductContext.GetContextInstance().Dispose();
        }
    }
}
