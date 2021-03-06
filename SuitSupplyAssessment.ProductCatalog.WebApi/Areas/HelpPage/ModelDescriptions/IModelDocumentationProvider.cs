using System;
using System.Reflection;

namespace SuitSupplyAssessment.ProductCatalog.WebApi.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}