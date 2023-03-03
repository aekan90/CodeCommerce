
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCC;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // AUTOFAC İLE NESNE ÜRETEN YER BURASI
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            if (true) // // EfProductDal, InMemoryDal : IProductDal
            {
                builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance(); 
            }

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // FLUENT VALIDATION İLE AOP (ASPECT VALIDATION) YAPILAN YER DE BURASI
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
