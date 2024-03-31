using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder) // uygulama ayağa kalktığında çalışacak
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); // builder.Services.AddSingleton<IProductService, ProductManager>()
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance(); // builder.Services.AddSingleton<IProductDal, EfProductDal>();
    }
}