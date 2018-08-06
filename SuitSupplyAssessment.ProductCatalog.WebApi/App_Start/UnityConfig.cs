using SuitSupplyAssessment.ProductCatalog.Business;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SuitSupplyAssessment.ProductCatalog.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICreateProduct, CreateProduct>();
            container.RegisterType<IGetProduct, GetProduct>();
            container.RegisterType<IUpdateProduct, UpdateProduct>();
            container.RegisterType<IRemoveProduct, RemoveProduct>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}