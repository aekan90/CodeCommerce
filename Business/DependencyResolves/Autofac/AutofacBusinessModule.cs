
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            if (true) // // EfProductDal, InMemoryDal : IProductDal
            {
                builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            }
            
        }
    }
}
